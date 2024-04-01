using DemoShop.Admin.WebApi;

namespace DemoShop.Admin.Services;

public class UserMangerService
{
    private readonly HttpContext _httpContext;
    public UserMangerService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor?.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }
    public bool IsUserValid(LoginInDTO request)
    {
        //TODO 轉寫實際的User判斷邏輯，這裡只是簡單的範例
        return !string.IsNullOrEmpty(request.UserName) == !string.IsNullOrEmpty(request.Password);
    }
    
    public bool IsAuthenticated()
    {
        return _httpContext.User.Identity?.IsAuthenticated ?? false;
    }
    
    public string GetUserName()
    {
        if (!IsAuthenticated()) return string.Empty;
        
        return _httpContext.User.Identity?.Name ?? string.Empty;
    }
}