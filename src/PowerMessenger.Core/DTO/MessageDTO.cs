

namespace PowerMessenger.Core.DTO
{
    public class MessageDTO
    {
        public long Id { get; set; }
        public string? Content { get; set; }
        public DateTime DateCreate { get; set; }
        public string? MessageOwner { get; set; }
        public string? MessageOwnerAvatar { get; set; }
        public bool IsRead { get; set; }
        public bool IsOwner { get; set; }
    }
}
