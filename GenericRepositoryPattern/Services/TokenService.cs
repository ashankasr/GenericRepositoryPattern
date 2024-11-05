using GenericRepositoryPattern.Interfaces.Services;

namespace GenericRepositoryPattern.Services;

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