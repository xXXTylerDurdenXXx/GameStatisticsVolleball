using GameStatisticsVolleball.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStatisticsVolleball.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly APIDBContext _context;
        public TournamentRepository(APIDBContext context)
        {
            _context = context;
        }
        public Tournament Create(Tournament entity)
        {
            _context.Tournament.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var tournament = _context.Tournament.Find(id);
            if (tournament == null)
                return false;

            _context.Tournament.Remove(tournament);
            _context.SaveChanges();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.Tournament.Any(t => t.Id == id);
        }

        public IEnumerable<Tournament> GetAll()
        {
            return _context.Tournament.ToList();
        }

        public Tournament GetById(int id)
        {
            return _context.Tournament
                .Include(t => t.Id)
                .FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Match> GetMatchesByTournamentId(int tournamentId)
        {
            return _context.Match
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Where(m => m.Tournament.Id == tournamentId)
                .ToList();
        }

        public IEnumerable<Team> GetTeamsByTournamentId(int tournamentId)
        {
            return _context.Match
         .Where(m => m.Tournament.Id == tournamentId)
         .Include(m => m.HomeTeam)
         .Include(m => m.AwayTeam)
         .SelectMany(m => new[] { m.HomeTeam, m.AwayTeam })
         .Distinct()
         .ToList();
        }

        public Tournament Update(Tournament entity)
        {
            _context.Tournament.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
