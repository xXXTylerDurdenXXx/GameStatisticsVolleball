namespace GameStatisticsVolleball.Models.DTO
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int Number { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public string PositionName { get; set; } = null!;
        public string TeamName { get; set; } = null!;
    }
}
