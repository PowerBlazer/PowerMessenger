using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerMessenger.Core.Entities;


namespace PowerMessenger.Infrastructure.Configurations
{
    public class MessageStatusConfiguration : IEntityTypeConfiguration<MessageStatus>
    {
        public void Configure(EntityTypeBuilder<MessageStatus> entity)
        {
            entity.HasKey(x => x.Id);

            entity.HasOne(p => p.Message)
                .WithMany(p => p.messageStatuses);


            entity.HasOne(p => p.User)
                .WithMany(p => p.messageStatuses);
        }
    }
}
