using System.ComponentModel.DataAnnotations;

namespace GameStatisticsVolleball.Models
{
    public class Position
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        
        public string NamePosition { get; set; } = null!;
        [MaxLength(200)]
        public string? Description {  get; set; } 

    }
}
