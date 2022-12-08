using Microsoft.AspNetCore.Mvc;
using PowerMessenger.Core.Repository;

namespace PowerMessenger.WebAPI.Controllers
{
    
    public class HomeController:ControllerBase
    {
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers([FromServices]IUserRepository userRepository)
        {
            return Ok(await userRepository.GetAllAsync());
        }
    }
}
