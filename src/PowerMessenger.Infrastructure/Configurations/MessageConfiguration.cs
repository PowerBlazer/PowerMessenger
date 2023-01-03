using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerMessenger.Core.Entities;

namespace PowerMessenger.Infrastructure.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> entity)
        {
            entity.HasOne(p => p.User)
                .WithMany(p => p.messages)
                .HasForeignKey(p=>p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(p => p.Chat)
                .WithMany(p => p.messages)
                .HasForeignKey(p=>p.ChatId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(new Message[]
            {
                new Message
                {
                    Id = 1,
                    UserId = 1,
                    ChatId = 1,
                    Content = "Привет",
                },
                new Message
                {
                    Id = 2,
                    UserId = 2,
                    ChatId = 1,
                    Content = "Дарова",
                },
                new Message
                {
                    Id = 3,
                    UserId = 1,
                    ChatId = 1,
                    Content = "Как дела?",
                },
                new Message
                {
                    Id = 4,
                    UserId = 2,
                    ChatId = 1,
                    Content = "Нормально"
                },
                new Message
                {
                    Id = 5,
                    UserId = 1,
                    ChatId = 1,
                    Content = "HelloWorld" 
                }
            });
                
        }
    }
}
