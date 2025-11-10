using GameStatisticsVolleball.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStatisticsVolleball.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly APIDBContext _context;
        public TeamRepository(APIDBContext context)
        {
            _context = context;
        }
        public Team Create(Team entity)
        {
            _context.Team.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var team = GetById(id);
            if (team == null)
                return false;

            _context.Team.Remove(team);
            _context.SaveChanges();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.Team.Any(p => p.Id == id);
        }

        public IEnumerable<Team> GetAll()
        {
            return _context.Team.ToList();
        }

        public Team GetById(int id)
        {
            return _context.Team.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Player> GetPlayersByTeamId(int teamId)
        {
            return _context.Player
                .Include(t => t.Team)
                .Where(t => t.Team.Id == teamId)
                .ToList();
        }

        public Team Update(Team entity)
        {
            _context.Team.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
