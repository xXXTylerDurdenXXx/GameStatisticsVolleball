using GameStatisticsVolleball.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStatisticsVolleball.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly APIDBContext _context;

        public PlayerRepository(APIDBContext context)
        {
            _context = context;
        }
        public Player Create(Player entity)
        {
            _context.Player.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var player = GetById(id);
            if (player == null)
                return false;

            _context.Player.Remove(player);
            _context.SaveChanges();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.Player.Any(p => p.Id == id);
        }

        public IEnumerable<Player> GetAll()
        {
            return _context.Player
           .Include(p => p.Team)
           .Include(p => p.Position)
           .ToList();
        }

        public Player GetById(int id)
        {
            var player = _context.Player
                .Include(p => p.Team)
                .Include(p => p.Position)
                .FirstOrDefault(p => p.Id == id);
            return player;

        }

        public async Task<IEnumerable<Player>> GetPlayersWithTeamsAndPositionsAsync()
        {
            return await _context.Player
            .Include(p => p.Team)
            .Include(p => p.Position)
            .ToListAsync();
        }

        public Player Update(Player entity)
        {
            _context.Player.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }


}
