namespace GameStatisticsVolleball.Models.DTO
{
    public class CreatePlayerMatchStatsDTO
    {
        public int PlayerId { get; set; }
        public int MatchId { get; set; }

        public int Points { get; set; }
        public int Aces { get; set; }
        public int Blocks { get; set; }
        public int Attacks { get; set; }
        public int AttackErrors { get; set; }
        public int Receptions { get; set; }
        public int ReceptionErrors { get; set; }
        public int Sets { get; set; }
    }
}
