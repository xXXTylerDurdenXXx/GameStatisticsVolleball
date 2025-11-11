namespace GameStatisticsVolleball.Models.DTO
{
    public class UpdatePlayerDTO
    {
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int Number { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public int PositionId { get; set; }
        public int TeamId { get; set; }
    }
}
