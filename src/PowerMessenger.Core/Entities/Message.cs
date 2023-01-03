using PowerMessenger.Core.Entities.bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerMessenger.Core.Entities
{
    #pragma warning disable CS8618
    public class Message:BaseEntity
    {
        /// <summary>
        /// Id чата
        /// </summary>
        [ForeignKey("ChatId")]
        public long ChatId { get; set; }
        public Chat Chat { get; set; }
        /// <summary>
        /// Владелец отправителя сообщения 
        /// </summary>
        [ForeignKey("UserId")]
        public long UserId { get; set; }
        public User User { get; set; }
        /// <summary>
        /// Содержимое сообщения
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// Дата отправления сообщения
        /// </summary>
        public DateTime date_create { get; set; } = DateTime.Now;
        public ICollection<MessageStatus> messageStatuses { get; set; }
    }
}
