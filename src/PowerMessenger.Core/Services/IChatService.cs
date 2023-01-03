

using PowerMessenger.Core.DTO;

namespace PowerMessenger.Core.Services
{
    public interface IChatService
    {
        Task<IEnumerable<ChatDTO>> GetChatsInUserAsync(string userId);
        Task<ChatDTO> GetChatByIdAsync(string chatid);
    }
}
