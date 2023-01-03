using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerMessenger.Core.Entities;

namespace PowerMessenger.Infrastructure.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> entity)
        {
            entity.HasOne(p => p.User)
                .WithMany(p => p.contacts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            entity.HasOne(p => p.Friend)
                .WithMany(p => p.contactsForFriend)
                .HasForeignKey(p=>p.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
