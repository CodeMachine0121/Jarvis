namespace Jarvis.Services;

public class TokenService
{
    private IConfiguration _config;

    public TokenService(IConfiguration config)
    {
        _config = config;
    }

    public string GetToken(string type)
    {
        return _config[$"Token:{type}"];
    }
}