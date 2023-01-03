using Microsoft.Extensions.Logging;
using PowerMessenger.Core.DTO;
using PowerMessenger.Core.Repository;
using PowerMessenger.Core.Services;

namespace PowerMessenger.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository= chatRepository;
        }

        public async Task<IEnumerable<ChatDTO>> GetChatsInUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return Enumerable.Empty<ChatDTO>();
            }

            IEnumerable<ChatDTO> chats = await _chatRepository.GetChatsInUserAsync(userId);

            chats = chats.OrderByDescending(p => p.CountUnReadMessages);

            return chats;
        }

        public async Task<ChatDTO> GetChatByIdAsync(string chatid)
        {
            if (string.IsNullOrEmpty(chatid))
            {
                return new ChatDTO();
            }

            ChatDTO chat = await _chatRepository.GetChatByIdAsync(chatid);

            return chat;
        }
    }
}
