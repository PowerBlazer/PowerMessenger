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
                .OnDelete(DeleteBehavior.Restrict);


            entity.HasOne(p => p.Friend)
                .WithMany(p => p.contactsForFriend)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
