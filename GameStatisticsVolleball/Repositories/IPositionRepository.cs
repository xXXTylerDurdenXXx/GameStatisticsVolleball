using GameStatisticsVolleball.Models;

namespace GameStatisticsVolleball.Repositories
{
    public interface IPositionRepository: IReposirory<Position>
    {
        public IEnumerable<Player> GetPlayersByPositionId(int positionId);
    }
}
