using PowerMessenger.Core.DTO;
using PowerMessenger.Core.Entities;
using PowerMessenger.Core.Repository.bases;

namespace PowerMessenger.Core.Repository
{
    public interface IMessageRepository:IRepositoryAsync<Message>
    {
        Task<IEnumerable<MessageDTO>> GetMessagesByChatId(string chatId, string userId);
        Task<int> GetAmountUnReadMessagesByChat(string chatId, string userId);
    }
}
