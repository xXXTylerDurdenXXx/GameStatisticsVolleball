using GameStatisticsVolleball.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStatisticsVolleball.Repositories
{
    public class PlayerMatchStatsRepository : IPlayerMatchStatsRepository
    {
        private readonly APIDBContext _context;

        public PlayerMatchStatsRepository(APIDBContext context)
        {
            _context = context;
        }

        public PlayerMatchStats Create(PlayerMatchStats entity)
        {
            _context.PlayerMatchStats.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var stats = GetById(id);
            if (stats == null)
                return false;

            _context.PlayerMatchStats.Remove(stats);
            _context.SaveChanges();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.PlayerMatchStats.Any(pms => pms.Id == id);
        }

        public IEnumerable<PlayerMatchStats> GetAll()
        {
            return _context.PlayerMatchStats.ToList();
        }

        public PlayerMatchStats GetById(int id)
        {
            return _context.PlayerMatchStats.FirstOrDefault(pms => pms.Id == id);
        }

        public IEnumerable<PlayerMatchStats> GetByMatchId(int matchId)
        {
            return _context.PlayerMatchStats
                .Where(pms => pms.Match.Id == matchId)
                .Include(pms => pms.Player) 
                .Include(pms => pms.Match) 
                .OrderBy(pms => pms.Player.FullName)
                .ToList();
        }

        public IEnumerable<PlayerMatchStats> GetByPlayerId(int playerId)
        {
            return _context.PlayerMatchStats
                .Where(pms => pms.Player.Id == playerId)
                .Include(pms => pms.Match)
                .Include(pms => pms.Player)
                .OrderByDescending(pms => pms.Match.Date)
                .ToList();
        }

        public PlayerMatchStats Update(PlayerMatchStats entity)
        {
            _context.PlayerMatchStats.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
