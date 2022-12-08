using PowerMessenger.Core.Entities.bases;


namespace PowerMessenger.Core.Entities
{
    #pragma warning disable CS8618
    public class Contact:BaseEntity
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Контакт
        /// </summary>
        public User Friend { get; set; }
    }
}
