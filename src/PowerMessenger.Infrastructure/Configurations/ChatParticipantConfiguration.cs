using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerMessenger.Core.Entities;


namespace PowerMessenger.Infrastructure.Configurations
{
    public class ChatParticipantConfiguration : IEntityTypeConfiguration<ChatParticipant>
    {
        public void Configure(EntityTypeBuilder<ChatParticipant> entity)
        {
            entity.HasOne(p => p.user)
                .WithMany(p => p.participantsChats)
                .OnDelete(DeleteBehavior.Restrict);


            entity.HasOne(p => p.chat)
                .WithMany(p => p.chatParticipants)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
