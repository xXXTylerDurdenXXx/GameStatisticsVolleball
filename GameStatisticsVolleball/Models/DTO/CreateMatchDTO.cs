namespace GameStatisticsVolleball.Models.DTO
{
    public class CreateMatchDTO
    {
        public DateTime MatchDate { get; set; }

        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }

        public int? TournamentId { get; set; }

        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }
    }
}
