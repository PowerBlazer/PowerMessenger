using PowerMessenger.Core.DTO;
using PowerMessenger.Core.Entities;
using PowerMessenger.Core.Repository.bases;

namespace PowerMessenger.Core.Repository
{
    public interface IChatRepository:IRepositoryAsync<Chat>
    {
        public Task<IEnumerable<ChatDTO>> GetChatsInUserAsync(string userId);
        public Task<ChatDTO> GetChatByIdAsync(string chatId);
    } 
}
