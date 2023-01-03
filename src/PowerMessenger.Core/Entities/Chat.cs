
using PowerMessenger.Core.Entities.bases;
using System.ComponentModel.DataAnnotations;

namespace PowerMessenger.Core.Entities
{
    #pragma warning disable CS8618
    public class Chat : BaseEntity
    {
        ///<summary>
        ///Заголовок чата
        ///</summary>
        [StringLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Описание чата
        /// </summary>
        [StringLength(200)]
        public string? Description { get; set; }
        /// <summary>
        /// Ссылка на фото чата
        /// </summary>
        public string? Photo { get; set; }       
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime date_created { get; set; } = DateTime.Now;


        public ICollection<Message> messages { get; set; }
        public ICollection<ChatParticipant> chatParticipants { get; set; }
        public ICollection<ChatOwner> chatOwners { get; set; }

    }
}
