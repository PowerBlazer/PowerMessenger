using Dapper;
using Microsoft.Extensions.Logging;
using PowerMessenger.Core.Contexts;
using PowerMessenger.Core.DTO;
using PowerMessenger.Core.Entities;
using PowerMessenger.Core.Repository;
using System.Data;

namespace PowerMessenger.Infrastructure.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly IApplicationContextDapper _contextDapper;
        private readonly ILogger<ChatRepository> _logger;

        public ChatRepository(IApplicationContextDapper contextDapper, ILogger<ChatRepository> logger)
        {
            _contextDapper = contextDapper;
            _logger = logger;
        }

        public Task<Chat> AddAsync(Chat entity)
        {
            throw new NotImplementedException();
        }

        public Task<Chat> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Chat>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Chat> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ChatDTO> GetChatByIdAsync(string chatId)
        {
            string query = @"select Chats.Id as 'ChatId',
	        Chats.Name as 'Name',
	        Chats.Photo as 'ChatPhoto',
	        count(ChatParticipant.Id) as 'CountParticipants'
	            from Chats 
			        left join ChatParticipant on ChatParticipant.chatId = Chats.Id
	        where Chats.Id = @chatId 
            group by Chats.Id,Chats.Name,Chats.Photo;";

            using IDbConnection connection = _contextDapper.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<ChatDTO>(query, new
            {
                chatId = chatId
            });

            _logger.LogInformation(query);

            return result;
        }

        public async Task<IEnumerable<ChatDTO>> GetChatsInUserAsync(string userId)
        {
            string query = @"select
            Chats.Name as 'Name',
            Chats.Id as 'ChatId',
            Chats.Photo as 'ChatPhoto',
            
	        (select count(Messages.Id) from Messages 
			    inner join MessageStatuses on MessageStatuses.MessageId = Messages.Id		
		    where Messages.ChatId = Chats.Id and MessageStatuses.isRead = 0 
			    and MessageStatuses.UserId != @userId) as 'CountUnReadMessages',

	        (select Messages.Content from Messages 
		        where Messages.ChatId = Chats.Id order by Messages.date_create desc limit 1) as 'LastMessage',

	        (select Users.Name from Messages 
		        inner join Users on Users.Id = Messages.UserId
		    where Messages.ChatId = Chats.Id order by Messages.date_create desc limit 1) as 'LastMessageOwner',

            (select Messages.date_create from Messages
                    where Messages.ChatId = Chats.Id order by Messages.date_create desc limit 1) as 'LastMessageTime',
            (select count(chatparticipant.id) from chatparticipant 
                    where chatparticipant.chatId = Chats.Id) as 'CountParticipants'

            from Chats 
                    inner join ChatParticipant on ChatParticipant.chatId = Chats.Id
	        where ChatParticipant.userId = @userId";

            using IDbConnection connection = _contextDapper.CreateConnection();

            var result = await connection.QueryAsync<ChatDTO>(query, new
            {
                userId = userId
            });

            _logger.LogInformation(query,userId);

            return result;
        }



        public Task<Chat> UpdateAsync(Chat entity)
        {
            throw new NotImplementedException();
        }
    }
}
