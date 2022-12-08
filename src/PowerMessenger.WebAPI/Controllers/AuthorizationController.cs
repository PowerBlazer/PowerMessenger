using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PowerMessenger.WebAPI.Controllers.bases;
using PowerMessenger.Core.DTO.Authorization;
using PowerMessenger.Core.Services;
using Newtonsoft.Json.Linq;

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
                 return BadRequest(authorizeResult.Errors);
             }
        
             Response.Cookies.Append(".AspNetCore.Application.Id", authorizeResult.Token!, new CookieOptions
             {
                 MaxAge = TimeSpan.FromMinutes(60),
             });
        
             return Ok(authorizeResult);
        
        }
        
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO loginDTO)
        {
             var authorizeResult = await _authorizationService.Login(loginDTO);
        
             if (!authorizeResult.IsSuccess)
             {
                 return BadRequest(authorizeResult.Errors);
             }
        
             Response.Cookies.Append(".AspNetCore.Application.Id", authorizeResult.Token!, new CookieOptions
             {
                 MaxAge = TimeSpan.FromMinutes(60),
             });
        
             return Ok(authorizeResult);
        } 
    }
}
