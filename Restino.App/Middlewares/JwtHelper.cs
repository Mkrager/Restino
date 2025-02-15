using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class JwtHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public JwtHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUserIdFromToken()
    {
        var token = _httpContextAccessor.HttpContext.Request.Cookies["access_token"];

        if (string.IsNullOrEmpty(token))
            return null;

        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

        var userIdClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == "uid");

        return userIdClaim?.Value;
    }

    public string GetUserRoleFromToken()
    {
        var token = _httpContextAccessor.HttpContext.Request.Cookies["access_token"];
        if (string.IsNullOrEmpty(token))
            return string.Empty;

        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
        var roleClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == "roles");

        return roleClaim?.Value ?? string.Empty;
    }
}
