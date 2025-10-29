using System.ComponentModel.DataAnnotations;

namespace GameStatisticsVolleball.Models
{
    public class Match
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(100)]
        public string? Location { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        // Навигационные свойства
        public Team HomeTeam { get; set; } = null!;
        public Team AwayTeam { get; set; } = null!;
        public Tournament? Tournament { get; set; }
        public ICollection<PlayerMatchStats>? PlayerStats { get; set; }
    }
}

