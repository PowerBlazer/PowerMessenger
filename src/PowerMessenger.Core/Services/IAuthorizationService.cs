
using PowerMessenger.Core.Common;
using PowerMessenger.Core.DTO.Authorization;

namespace PowerMessenger.Core.Services
{
    public interface IAuthorizationService
    {
        Task<AuthorizationResult> Register(RegisterDTO registerDTO);
        Task<AuthorizationResult> Login(LoginDTO loginDTO);
        void Logout();
    }
}
