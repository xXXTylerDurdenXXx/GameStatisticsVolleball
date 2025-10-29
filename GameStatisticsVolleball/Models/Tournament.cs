using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GameStatisticsVolleball.Models
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Season { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
        public ICollection<Match>? Matches { get; set; }
    }
}

