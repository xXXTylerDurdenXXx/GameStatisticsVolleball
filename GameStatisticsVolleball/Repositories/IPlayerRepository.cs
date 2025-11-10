namespace GameStatisticsVolleball.Repositories

{
    using GameStatisticsVolleball.Models;
    public interface IPlayerRepository: IReposirory<Player>
    {
        Task<IEnumerable<Player>> GetPlayersWithTeamsAndPositionsAsync();
    }
}
