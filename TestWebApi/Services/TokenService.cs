using TestWebApi.Interfaces.Services;

namespace TestWebApi.Services;

public class TokenService : ITokenService
{
    public TokenService(IConfiguration configuration)
    {
    }

    public string GetUsername()
    {
        return "username";
    }
}