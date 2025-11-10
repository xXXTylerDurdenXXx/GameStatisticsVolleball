using GameStatisticsVolleball.Models;

namespace GameStatisticsVolleball.Repositories
{
    public interface IPlayerMatchStatsRepository: IReposirory<PlayerMatchStats>
    {
        IEnumerable<PlayerMatchStats> GetByPlayerId(int playerId);
        IEnumerable<PlayerMatchStats> GetByMatchId(int matchId);
    }
}
