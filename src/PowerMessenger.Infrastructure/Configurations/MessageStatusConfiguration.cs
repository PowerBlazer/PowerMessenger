using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerMessenger.Core.Entities;


namespace PowerMessenger.Infrastructure.Configurations
{
    public class MessageStatusConfiguration : IEntityTypeConfiguration<MessageStatus>
    {
        public void Configure(EntityTypeBuilder<MessageStatus> entity)
        {
            entity.HasOne(p => p.Message)
                .WithMany(p => p.messageStatuses)
                .HasForeignKey(p => p.MessageId);


            entity.HasOne(p => p.User)
                .WithMany(p => p.messageStatuses)
                .HasForeignKey(p=>p.UserId);

            entity.HasData(new MessageStatus[]
            {
                new MessageStatus
                {
                    Id = 1,
                    MessageId = 1,
                    UserId = 1,
                    isRead = false
                },
                new MessageStatus
                {
                    Id = 2,
                    MessageId = 1,
                    UserId = 2,
                    isRead = false
                },
                new MessageStatus
                {
                    Id = 3,
                    MessageId = 2,
                    UserId = 1,
                    isRead = false
                },
                new MessageStatus
                {
                    Id = 4,
                    MessageId = 2,
                    UserId = 2,
                    isRead = false
                },
                new MessageStatus
                {
                    Id = 5,
                    MessageId= 3,
                    UserId = 1,
                    isRead = false
                },
                new MessageStatus
                {
                    Id = 6,
                    MessageId = 3,
                    UserId = 2,
                    isRead = false
                },
                new MessageStatus
                {
                    Id = 7,
                    MessageId = 4,
                    UserId = 1,
                    isRead = false
                },
                new MessageStatus
                {
                    Id = 8,
                    MessageId = 4,
                    UserId = 2,
                    isRead = false
                },
                new MessageStatus
                {
                    Id = 9,
                    MessageId = 5,
                    UserId = 1,
                    isRead = false
                },
                new MessageStatus
                {
                    Id = 10,
                    MessageId = 5,
                    UserId = 2,
                    isRead = false
                },
            });
        }
    }
}
