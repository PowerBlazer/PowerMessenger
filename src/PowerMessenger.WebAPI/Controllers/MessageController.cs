using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerMessenger.Core.Services;
using PowerMessenger.WebAPI.Controllers.bases;

namespace PowerMessenger.WebAPI.Controllers
{
    [Authorize]
    [Route("Message")]
    public class MessageController:BaseController
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("getMessages/{chatId}")]
        public async Task<IActionResult> GetMessagesAsync([FromRoute]string chatId)
        {
            var result = await _messageService.GetMessagesByChatIdAsync(chatId, UserID);

            return Ok(result);
        }
    }
}
