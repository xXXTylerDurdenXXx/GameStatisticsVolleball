namespace GameStatisticsVolleball.Models.DTO
{
    public class CreateTeamDTO
    {
        public string Name { get; set; } = null!;
        public string CoachName { get; set; } = null!;

        public string City { get; set; } = null!;
        public string? Country { get; set; }
    }
}
