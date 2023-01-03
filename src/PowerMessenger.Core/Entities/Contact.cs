using PowerMessenger.Core.Entities.bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerMessenger.Core.Entities
{
#pragma warning disable CS8618
    public class Contact : BaseEntity
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        [ForeignKey("UserId")]
        public long UserId { get; set; }
        public User User { get; set; }
        /// <summary>
        /// Контакт
        /// </summary>
        [ForeignKey("FriendId")]
        public long FriendId { get; set; }
        public User Friend { get; set; }
        /// <summary>
        /// Название контакта
        /// </summary>
        public string ContactName { get; set; }
    }
}
