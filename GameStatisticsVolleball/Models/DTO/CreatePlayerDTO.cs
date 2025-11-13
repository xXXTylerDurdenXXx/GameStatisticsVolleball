using System.ComponentModel.DataAnnotations;

namespace GameStatisticsVolleball.Models.DTO
{
    public class CreatePlayerDTO
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [MinLength(2, ErrorMessage = "Имя должно содержать минимум 2 символа")]
        [MaxLength(50, ErrorMessage = "Имя не должно превышать 50 символов")]
        public string FullName { get; set; } = null!;
        [Required(ErrorMessage = "Дата рождения обязательна")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Номер игрока обязателен")]
        [Range(1, 99, ErrorMessage = "Номер игрока должен быть в диапазоне от 1 до 99")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Рост обязателен")]
        [Range(100, 250, ErrorMessage = "Рост должен быть в диапазоне от 100 до 250 см")]
        public int Height { get; set; }
        [Required(ErrorMessage = "Вес обязателен")]
        [Range(40, 150, ErrorMessage = "Вес должен быть в диапазоне от 40 до 150 кг")]
        public int Width { get; set; }
        [Required(ErrorMessage = "Необходимо указать позицию игрока")]
        public int PositionId { get; set; }
        [Required(ErrorMessage = "Необходимо указать команду игрока")]
        public int TeamId { get; set; }
    }
}
