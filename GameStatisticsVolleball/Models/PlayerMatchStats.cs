using System.ComponentModel.DataAnnotations;

namespace GameStatisticsVolleball.Models
{
    public class PlayerMatchStats
    {
        [Key]
        public int Id { get; set; }
        public int Points { get; set; }
        public int Aces { get; set; }
        public int Blocks { get; set; }
        public int Attacks { get; set; }
        public int AttackErrors { get; set; }
        public int Receptions { get; set; }
        public int ReceptionErrors { get; set; }
        public int Sets { get; set; }

        // Навигация
        public Player Player { get; set; } = null!;
        public Match Match { get; set; } = null!;
    }
}
