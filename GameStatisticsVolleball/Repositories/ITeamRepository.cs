using GameStatisticsVolleball.Models;

namespace GameStatisticsVolleball.Repositories
{
    public interface ITeamRepository: IReposirory<Team>
    {
        public IEnumerable<Player> GetPlayersByTeamId(int teamId);
    }
}
