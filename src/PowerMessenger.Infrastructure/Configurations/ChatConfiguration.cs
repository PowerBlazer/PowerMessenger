using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerMessenger.Core.Entities;

namespace PowerMessenger.Infrastructure.Configurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> entity)
        {
            entity.HasData(new Chat[]
            {
                new Chat
                {
                    Id = 1,
                    Name = "Group1",
                    Photo = "ChatsImage/efe4e2f6-d7b2-49f4-80bf-a2b5e8fa7178.jpg"
                }
            });
        }
    }
}
