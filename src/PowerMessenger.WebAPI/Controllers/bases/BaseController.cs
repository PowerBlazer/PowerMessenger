using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PowerMessenger.WebAPI.Controllers.bases
{
    public class BaseController:ControllerBase
    {
        internal string UserID => User.Claims.Single(p => p.Type == ClaimTypes.NameIdentifier).Value; 
    }
}
