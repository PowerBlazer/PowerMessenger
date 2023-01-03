

using PowerMessenger.Core.DTO;

namespace PowerMessenger.Core.Services
{
    public interface IMessageService
    {
        Task<MessagesDTO> GetMessagesByChatIdAsync(string chatId, string userId);
    }
}
