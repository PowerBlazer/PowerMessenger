

using Microsoft.EntityFrameworkCore;
using PowerMessenger.Core.Entities;

namespace PowerMessenger.Core.Contexts
{
    public interface IApplicationContextEF
    {
        DbSet<User> Users { get; set; }
        DbSet<Chat> Chats { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<MessageStatus> MessageStatuses { get; set; }
        DbSet<ChatParticipant> ChatParticipant { get; set; }
        DbSet<ChatOwner> ChatOwner { get; set; }
        Task<int> SaveChangesAsync();
    }
}
