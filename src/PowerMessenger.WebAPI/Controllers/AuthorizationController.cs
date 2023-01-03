using Microsoft.AspNetCore.Mvc;
using PowerMessenger.WebAPI.Controllers.bases;
using PowerMessenger.Core.DTO.Authorization;
using PowerMessenger.Core.Services;
using PowerMessenger.Core.Repository;

namespace PowerMessenger.WebAPI.Controllers
{
    [Route("Authorization")]
    public class AuthorizationController:BaseController
    {
        private readonly IAuthorizationService _authorizationService;
        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService= authorizationService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterDTO registerDTO)
        {
             var authorizeResult = await _authorizationService.Register(registerDTO);
        
             if(!authorizeResult.IsSuccess)
             {
                 return BadRequest(authorizeResult);
             }
             
             return Ok(authorizeResult);
        }
        
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO loginDTO)
        {
             var authorizeResult = await _authorizationService.Login(loginDTO);
        
             if (!authorizeResult.IsSuccess)
             {
                 return BadRequest(authorizeResult);
             }
                 
             return Ok(authorizeResult);
        }
        [HttpGet("Test")]
        public async Task<IActionResult> Test([FromServices]IUserRepository userRepository)
        {
            return Ok(await userRepository.GetAllUsersAsync());
        }

        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            _authorizationService.Logout();

            return Ok();
        }


        
    }
}
