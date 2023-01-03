using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerMessenger.Core.Entities;


namespace PowerMessenger.Infrastructure.Configurations
{
    public class ChatParticipantConfiguration : IEntityTypeConfiguration<ChatParticipant>
    {
        public void Configure(EntityTypeBuilder<ChatParticipant> entity)
        {          
            entity.HasOne(p => p.User)
                .WithMany(p => p.participantsChats)
                .HasForeignKey(p=>p.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            entity.HasOne(p => p.Chat)
                .WithMany(p => p.chatParticipants)
                .HasForeignKey(p=>p.ChatId)
                .OnDelete(DeleteBehavior.Restrict);


            entity.HasData(new ChatParticipant[]
            {
                new ChatParticipant
                {
                    Id = 1,
                    UserId = 1,
                    ChatId = 1,
                },
                new ChatParticipant
                {
                    Id =2,
                    UserId = 2,
                    ChatId = 1,
                }
            });
                
        }
    }
}
