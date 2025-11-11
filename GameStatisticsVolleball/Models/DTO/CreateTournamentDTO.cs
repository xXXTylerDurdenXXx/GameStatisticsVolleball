namespace GameStatisticsVolleball.Models.DTO
{
    public class CreateTournamentDTO
    {
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MatchesCount { get; set; }
    }
}
