using PowerMessenger.Core.Entities.bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerMessenger.Core.Entities
{
    #pragma warning disable CS8618
    public class ChatOwner: BaseEntity
    {
        /// <summary>
        /// Роль пользователя
        /// </summary>
        public string Role { get; set; }


        /// <summary>
        /// Id chat
        /// </summary>
        [ForeignKey("ChatId")]
        public long ChatId { get; set; }
        public Chat Chat { get; set; }
        /// <summary>
        /// Id User
        /// </summary>
        [ForeignKey("UserId")]
        public long UserId { get; set; }
        public User user { get; set; }
    }
}
