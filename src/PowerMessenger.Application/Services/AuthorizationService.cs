using PowerMessenger.Application.Common;
using PowerMessenger.Core.Common;
using PowerMessenger.Core.DTO.Authorization;
using PowerMessenger.Core.Entities;
using PowerMessenger.Core.Repository;
using PowerMessenger.Core.Services;
using System.ComponentModel.DataAnnotations;

namespace PowerMessenger.Application.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtToken _jwtToken;
        public AuthorizationService(IUserRepository userRepository,IJwtToken jwtToken)
        {
            _userRepository = userRepository;
            _jwtToken = jwtToken;
        }

        public async Task<AuthorizationResult> Login(LoginDTO loginDTO)
        {
            AuthorizationResult authorizationResult = new();

            List<ValidationResult> validationResults = new();
            ValidationContext validationContext = new(loginDTO);

            if (!Validator.TryValidateObject(loginDTO, validationContext, validationResults, true))
            {
                string[] errors = validationResults.Select(p=>p.ErrorMessage!).ToArray();

                authorizationResult.Failed(errors);

                return authorizationResult;
            }

            User user = await _userRepository.GetUserByEmailPasswordAsync(
                loginDTO.Email!,
                ComputeHash256.ComputeSha256Hash(loginDTO.Password!));

            if(user is null)
            {
                authorizationResult.Failed(new string[] { "Неправильный пароль или логин" });

                return authorizationResult;
            }

            authorizationResult.Token = _jwtToken.GenerateJWT(user!);
            
            return authorizationResult;

        }
        public async Task<AuthorizationResult> Register(RegisterDTO registerDTO)
        {
            AuthorizationResult authorizationResult = new();

            List<ValidationResult> validationResults = new();

            ValidationContext validationContext = new(registerDTO);

            if (!Validator.TryValidateObject(registerDTO, validationContext, validationResults, true))
            {
                string[] errors = validationResults.Select(p => p.ErrorMessage!).ToArray();

                authorizationResult.Failed(errors);

                return authorizationResult;
            }

            User user = new()
            {
                Id = Guid.NewGuid(),
                Name = registerDTO.UserName!,
                Email = registerDTO.Email!,
                PasswordHash = ComputeHash256.ComputeSha256Hash(registerDTO.Password!),
            };

            await _userRepository.AddAsync(user);

            authorizationResult.Token = _jwtToken.GenerateJWT(user);

            return authorizationResult;
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

       
    }
}
