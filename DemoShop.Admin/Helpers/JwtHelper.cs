using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace DemoShop.Admin.Helpers
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AuthResultDto GenerateToken(string userName, int expireMinute = 30)
        {
            // 取得設定檔中的相關設定
            var issuer = _configuration.GetValue<string>("JwtSettings:Issuer");
            var signKey = _configuration.GetValue<string>("JwtSettings:SignKey");

            // 設定要加入到 JWT Token 中的聲明資訊
            var claims = new List<Claim>();

            // 使用定義的規格
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userName));
            claims.Add(new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            // 自行擴充
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            claims.Add(new Claim(ClaimTypes.Role, "Users"));

            // 宣告集合所描述的身分識別
            var userClaimsIdentity = new ClaimsIdentity(claims);


            // 建立一組對稱式金鑰，主要用於　JWT  簽章之用  => 建立鑰匙
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));

            // 用來產生數位簽章的密碼編譯演算法  => 建立簽章
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // 預留位置，適用於已發行權杖相關的所有屬性，用來定義 JWT 的發行者、主題、接收者、過期時間、簽章等等
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = issuer,
                Subject = userClaimsIdentity,  // 身分識別
                Expires = DateTime.UtcNow.AddMinutes(expireMinute),  // 過期時間
                SigningCredentials = signingCredentials  // 簽章
            };

            // 建立 JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var serializeToken = tokenHandler.WriteToken(securityToken);

            return new AuthResultDto()
            {
                Token = serializeToken,
                Expiration = new DateTimeOffset(tokenDescriptor.Expires.Value).ToUnixTimeSeconds()
            };
        }
    }


    public class AuthResultDto
    {
        public string Token { get; set; }
        public long Expiration { get; set; }
    }
}
