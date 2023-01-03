
namespace PowerMessenger.Core.DTO
{
    public class MessagesDTO
    {
        public IEnumerable<MessageDTO>? Messages { get; set; }
        public int CountUnReadMessages { get; set; }
    }
}
