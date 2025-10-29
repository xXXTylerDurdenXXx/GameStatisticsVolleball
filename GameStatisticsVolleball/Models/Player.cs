using System.ComponentModel.DataAnnotations;

namespace GameStatisticsVolleball.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; } = null!;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Range(1, 99)]
        public int Number {  get; set; }
        [Required]
        [Range(0,250)]
        public int Height { get; set; }
        [Required]
        [Range(0, 150)]
        public int Width { get; set; }

        // Навигационные св-ва
        public Position Position { get; set; } = null!;
        public Team Team { get; set; } = null!;


    }
}
