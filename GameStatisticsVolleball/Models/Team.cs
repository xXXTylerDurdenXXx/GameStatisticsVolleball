using System.ComponentModel.DataAnnotations;

namespace GameStatisticsVolleball.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string City { get; set; } = null!;
        [Required]
        public string CoachName { get; set; } = null!;
    }
}
