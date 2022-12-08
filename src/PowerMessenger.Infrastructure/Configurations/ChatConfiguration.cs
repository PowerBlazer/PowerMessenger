using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerMessenger.Core.Entities;

namespace PowerMessenger.Infrastructure.Configurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> entity)
        {
            entity.HasOne(p => p.ownerUser)
                .WithMany(p => p.ownerChats);
                
        }
    }
}
