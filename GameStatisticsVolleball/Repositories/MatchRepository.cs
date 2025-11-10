using GameStatisticsVolleball.Models;

namespace GameStatisticsVolleball.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly APIDBContext _context;
        public MatchRepository(APIDBContext context)
        {
            _context = context;
        }
        public Match Create(Match entity)
        {
            _context.Match.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var match = GetById(id);
            if (match == null)
                return false;

            _context.Match.Remove(match);
            _context.SaveChanges();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.Match.Any(m => m.Id == id);
        }

        public IEnumerable<Match> GetAll()
        {
            return _context.Match.ToList();
        }

        public Match GetById(int id)
        {
            return _context.Match.FirstOrDefault(m => m.Id == id);
        }

        public Match Update(Match entity)
        {
            _context.Match.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
