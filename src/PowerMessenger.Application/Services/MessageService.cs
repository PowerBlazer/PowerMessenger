
using PowerMessenger.Core.DTO;
using PowerMessenger.Core.Exceptions;
using PowerMessenger.Core.Repository;
using PowerMessenger.Core.Services;

namespace PowerMessenger.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository= messageRepository;
        }
        public async Task<MessagesDTO> GetMessagesByChatIdAsync(string chatId, string userId)
        {

            if(string.IsNullOrEmpty(chatId) ||
                string.IsNullOrEmpty(userId))
            {
                throw new IsNullValueException("Не найдено");
            }

            var messages = new MessagesDTO
            {
                Messages = await _messageRepository.GetMessagesByChatId(chatId, userId),
                CountUnReadMessages = await _messageRepository.GetAmountUnReadMessagesByChat(chatId, userId),
            };

            return messages;
        }
    }
}
