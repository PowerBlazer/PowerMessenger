using PowerMessenger.Core.Entities.bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerMessenger.Core.Entities
{
    #pragma warning disable CS8618
    public class ChatParticipant:BaseEntity
    {
        /// <summary>
        /// Id Чата
        /// </summary>
        [ForeignKey("ChatId")]
        public long ChatId { get; set; }
        public Chat Chat { get; set; }
        /// <summary>
        /// Участник чата
        /// </summary>
        [ForeignKey("UserId")]
        public long UserId { get; set; }
        public User User { get; set; }
        /// <summary>
        /// Дата присоединения
        /// </summary>
        public DateTime dateOfJoin { get; set; } = DateTime.Now;
    }
}
