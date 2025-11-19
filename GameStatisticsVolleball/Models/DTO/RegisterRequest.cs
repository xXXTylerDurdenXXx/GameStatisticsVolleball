using System.ComponentModel.DataAnnotations;

namespace GameStatisticsVolleball.Models.DTO
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Введите Email")]
        [EmailAddress(ErrorMessage = "Некорректный формат Email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Введите имя пользователя")]
        [MinLength(3, ErrorMessage = "Имя пользователя должно быть минимум 3 символа")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен быть минимум 6 символов")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
