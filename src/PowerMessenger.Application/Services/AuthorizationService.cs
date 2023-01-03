using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtToken _jwtToken;
        public AuthorizationService(IUserRepository userRepository,IJwtToken jwtToken
            ,IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _jwtToken = jwtToken;
            _httpContextAccessor = httpContextAccessor;
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

            string passwordHash = ComputeHash256.ComputeSha256Hash(loginDTO.Password!);

            User user = await _userRepository.GetUserByPasswordAsync(loginDTO.Email!,passwordHash);

            if(user is null)
            {
                authorizationResult.Failed(new string[] { "Неправильный пароль или логин" });

                return authorizationResult;
            }

            string token = _jwtToken.GenerateJWT(user!);

            authorizationResult.Token = token;

            CookieAppendToken(token);
            
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

            User validateUser = await _userRepository.GetUserByEmailAsync(registerDTO.Email!);

            if(validateUser is not null)
            {
                authorizationResult.Failed(new string[] { "Этот email уже занят" });

                return authorizationResult;
            }

            User user = new()
            {           
                Name = registerDTO.UserName!,
                Email = registerDTO.Email!,
                PasswordHash = ComputeHash256.ComputeSha256Hash(registerDTO.Password!),
            };

            await _userRepository.AddUserAsync(user);

            string token = _jwtToken.GenerateJWT(user!);

            authorizationResult.Token = token;

            CookieAppendToken(token);

            return authorizationResult;
        }

        public void Logout()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(".AspNetCore.Application.Id");
        }




        private void CookieAppendToken(string token)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", token, new CookieOptions
            {
                MaxAge = TimeSpan.FromMinutes(60),
            });
        }


    }
}
