

using System.ComponentModel.DataAnnotations;

namespace PowerMessenger.Core.DTO.Authorization
{
    public class RegisterDTO
    {
        [Required (ErrorMessage ="Не указан логин ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Не указана почта")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Пароль не может быть пустым")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string? PasswordConfirm { get; set; }

    }
}
