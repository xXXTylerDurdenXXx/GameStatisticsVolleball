using GameStatisticsVolleball.Models;

namespace GameStatisticsVolleball.Repositories
{
    public interface ITournamentRepository: IReposirory<Tournament>
    {
        public IEnumerable<Match> GetMatchesByTournamentId(int tournamentId);
        IEnumerable<Team> GetTeamsByTournamentId(int tournamentId);
    }
}
