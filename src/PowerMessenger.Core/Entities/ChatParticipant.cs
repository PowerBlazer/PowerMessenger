using PowerMessenger.Core.Entities.bases;

namespace PowerMessenger.Core.Entities
{
    #pragma warning disable CS8618
    public class ChatParticipant:BaseEntity
    {
        /// <summary>
        /// Id Чата
        /// </summary>
        public Chat chat { get; set; }
        /// <summary>
        /// Участник чата
        /// </summary>
        public User user { get; set; }
        /// <summary>
        /// Дата присоединения
        /// </summary>
        public DateTime dateOfJoin { get; set; } = DateTime.Now;
    }
}
