

using System.ComponentModel.DataAnnotations;

namespace PowerMessenger.Core.DTO.Authorization
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Не указана почта")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Пароль не может быть пустым")]
        public string? Password { get; set; }  
    }
}
