using Microsoft.EntityFrameworkCore;
using PowerMessenger.Core.Contexts;
using PowerMessenger.Core.Entities;
using PowerMessenger.Infrastructure.Configurations;

namespace PowerMessenger.Infrastructure.Contexts
{
    #pragma warning disable CS8618
    public class ApplicationContextEF : DbContext, IApplicationContextEF
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageStatus> MessageStatuses { get; set; }
        public DbSet<ChatParticipant> ChatParticipants { get; set; }
        public DbSet<ChatOwner> ChatOwners { get; set; }
        public DbSet<ChatParticipant> ChatParticipant { get; set; }
        public DbSet<ChatOwner> ChatOwner { get; set; }

        public ApplicationContextEF(DbContextOptions<ApplicationContextEF> options) : base(options)
        {           
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new MessageStatusConfiguration());
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new ChatParticipantConfiguration());
            builder.ApplyConfiguration(new ChatConfiguration());
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }


}
