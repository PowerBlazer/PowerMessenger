using PowerMessenger.Core.Entities;


namespace PowerMessenger.Core.Services
{
    public interface IJwtToken
    {
        string GenerateJWT(User user);
    }
}
