
using PowerMessenger.Core.Entities.bases;
using System.ComponentModel.DataAnnotations;

namespace PowerMessenger.Core.Entities
{
    #pragma warning disable CS8618
    public class User:BaseEntity
    {
        ///<summary>
        ///Логин польователя
        ///</summary>
        [StringLength(100)]
        public string Name { get; set; }
        ///<summary>
        ///Хешированный пароль пользователя
        ///</summary>
        public string PasswordHash { get; set; }
        ///<summary>
        ///Почтка польователя
        ///</summary>
        public string Email { get; set; }
        ///<summary>
        ///Номер телефона пользователя
        ///</summary>
        [StringLength(30)]
        public string? PhoneNumber { get; set; }
        ///<summary>
        ///Дата регистрации пользователя
        ///</summary>
        public DateTime DateRegistration { get; set; } = DateTime.Now;
        ///<summary>
        ///Ссылка на изображение аватарки
        ///</summary>
        public string? Photo { get; set; }

        /// <summary>
        /// Контакты
        /// </summary>
        public ICollection<Contact> contacts { get; set; }
        ///<summary>
        ///Контакты со стороны другого пользователя 
        ///</summary>
        public ICollection<Contact> contactsForFriend { get; set; }
        public ICollection<Message> messages { get; set; }
        public ICollection<Chat> ownerChats { get; set; }
        public ICollection<MessageStatus> messageStatuses { get; set; }
        public ICollection<ChatParticipant> participantsChats { get; set; }


    }
}
