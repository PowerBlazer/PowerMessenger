using PowerMessenger.Core.Entities.bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerMessenger.Core.Entities
{
    public class MessageStatus : BaseEntity
    {
#pragma warning disable CS8618
        /// <summary>
        /// Id сообщения
        /// </summary>
        [ForeignKey("MessageId")]
        public long MessageId { get; set; }
        public Message Message { get; set; }
        /// <summary>
        /// Id пользователя
        /// </summary>
        [ForeignKey("UserId")]
        public long UserId { get; set; }
        public User User { get; set; }
        /// <summary>
        /// Прочитано ли сообщение
        /// </summary>
        public bool isRead { get; set; }

        
    }
}
