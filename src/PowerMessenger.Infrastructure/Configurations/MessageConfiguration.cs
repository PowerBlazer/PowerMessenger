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
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(p => p.Chat)
                .WithMany(p => p.messages)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
