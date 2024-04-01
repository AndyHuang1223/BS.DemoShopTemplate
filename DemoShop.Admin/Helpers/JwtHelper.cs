using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DemoShop.Admin.Models.Settings;
using Microsoft.IdentityModel.Tokens;

namespace DemoShop.Admin.Helpers;

public class JwtHelper
{
    private readonly JwtSettings _jwtSettings;

    public JwtHelper(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public AuthResultDto GenerateToken(string userName, int expireMinute = 30)
    {
        var defaultRoles = new List<string> { "Admin", "Users" };
        return GenerateToken(userName, defaultRoles, expireMinute);
    }

    public AuthResultDto GenerateToken(string userName, IEnumerable<string> roles, int expireMinute = 30)
    {
        var issuer = _jwtSettings.Issuer;
        var signKey = _jwtSettings.SignKey;

        // 設定要加入到 JWT Token 中的聲明
        var claims = new List<Claim>();

        //使用定義的規格 https://datatracker.ietf.org/doc/html/rfc7519#section-4.1
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userName));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

        // 自行擴充
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        // 宣告集合所描述的身分識別
        var userClaimsIdentity = new ClaimsIdentity(claims);

        // 建立一組對稱式加密的金鑰，主要用於 JWT 簽章之用
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));

        // 用來產生數位簽章的密碼編譯演算法
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        // 預留位置，適用於和已發行權杖相關的所有屬性，用來定義JWT的相關設定
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Issuer = issuer,
            Subject = userClaimsIdentity,
            Expires = DateTime.UtcNow.AddMinutes(expireMinute),
            SigningCredentials = signingCredentials
        };

        // 用來產生JWT
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var serializeToken = tokenHandler.WriteToken(securityToken);


        return new AuthResultDto()
        {
            Token = serializeToken,
            ExpireTime = new DateTimeOffset(tokenDescriptor.Expires.Value).ToUnixTimeSeconds(),
        };
    }

    public class AuthResultDto
    {
        public string Token { get; set; }
        public long ExpireTime { get; set; }
    }
}