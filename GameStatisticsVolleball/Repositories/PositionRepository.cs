using GameStatisticsVolleball.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStatisticsVolleball.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly APIDBContext _context;

        public PositionRepository(APIDBContext context)
        {
            _context = context;
        }
        public Position Create(Position entity)
        {
            _context.Position.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var pos = GetById(id);
            if (pos == null)
                return false;

            _context.Position.Remove(pos);
            _context.SaveChanges();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.Position.Any(p => p.Id == id);
        }

        public IEnumerable<Position> GetAll()
        {
            return _context.Position.ToList();
        }

        public Position GetById(int id)
        {
            return _context.Position.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Player> GetPlayersByPositionId(int positionId)
        {
            return _context.Player
           .Include(p => p.Position)
           .Where(p => p.Position.Id == positionId)
           .ToList();
        }

        public Position Update(Position entity)
        {
            _context.Position.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
