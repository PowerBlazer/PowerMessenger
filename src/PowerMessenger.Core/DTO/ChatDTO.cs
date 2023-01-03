

namespace PowerMessenger.Core.DTO
{
    public class ChatDTO
    {
        public long ChatId { get; set; }
        public string? Name { get; set; }
        public string? LastMessage { get; set; }
        public string? LastMessageOwner { get; set; }
        public DateTime LastMessageTime { get; set; }
        public int CountUnReadMessages { get; set; }
        public string? ChatPhoto { get; set; }
        public int CountParticipants { get; set; }
    }
}
