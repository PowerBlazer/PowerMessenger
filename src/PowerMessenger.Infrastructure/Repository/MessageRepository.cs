

using Dapper;
using Microsoft.Extensions.Logging;
using PowerMessenger.Core.Contexts;
using PowerMessenger.Core.DTO;
using PowerMessenger.Core.Entities;
using PowerMessenger.Core.Repository;
using System.Data;

namespace PowerMessenger.Infrastructure.Repository
{

    public class MessageRepository : IMessageRepository
    {
        private readonly IApplicationContextDapper _contextDapper;
        private readonly ILogger<MessageRepository> _logger;

        public MessageRepository(IApplicationContextDapper contextDapper,
            ILogger<MessageRepository> logger)
        {
            _contextDapper = contextDapper;
            _logger = logger;
        }

        public Task<Message> AddAsync(Message entity)
        {
            throw new NotImplementedException();
        }

        public Task<Message> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetAmountUnReadMessagesByChat(string chatId, string userId)
        {
            string query = @"select count(messagestatuses.Id) from messagestatuses
	            inner join messages on messages.Id = messagestatuses.MessageId and messages.ChatId = @chatId
            where messagestatuses.userId = @userId and messagestatuses.isRead = 0";

            IDbConnection connection = _contextDapper.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<int>(query, new
            {
                userId = userId,
                chatId = chatId,
            });

            _logger.LogInformation(query);

            return result;
        }

        public Task<Message> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MessageDTO>> GetMessagesByChatId(string chatId, string userId)
        {
            string queryMessages = @"call GetMessages(@chatId,@userId)";
            
            IDbConnection connection = _contextDapper.CreateConnection();

            var result = await connection.QueryAsync<MessageDTO>(queryMessages, new
            {
                chatId = chatId,
                userId = userId
            });

            _logger.LogInformation(queryMessages);

            return result;
        }

        public Task<Message> UpdateAsync(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
