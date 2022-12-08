using PowerMessenger.Core.Entities.bases;


namespace PowerMessenger.Core.Entities
{
    public class MessageStatus:BaseEntity
    {
        #pragma warning disable CS8618
        /// <summary>
        /// Id сообщения
        /// </summary>
        public Message Message { get; set; }
        /// <summary>
        /// Id пользователя
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Прочитано ли сообщение
        /// </summary>
        public bool isRead { get; set; }

        
    }
}
