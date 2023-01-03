
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerMessenger.Core.Services;
using PowerMessenger.WebAPI.Controllers.bases;

namespace PowerMessenger.WebAPI.Controllers
{
    [Authorize]
    [Route("Chats")]
    public class ChatsController:BaseController
    {
        private readonly IChatService _chatService;
        public ChatsController(IChatService chatService)
        {
            _chatService = chatService;
        }


        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetChatsInUser()
        {
            var result = await _chatService.GetChatsInUserAsync(UserID);

            return Ok(result);
        }

        [HttpGet("chat/{chatId}")]
        public async Task<IActionResult> GetChatById([FromRoute]string chatId)
        {
            var result = await _chatService.GetChatByIdAsync(chatId);

            return Ok(result);
        }


    }
}
