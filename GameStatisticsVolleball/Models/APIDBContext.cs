using Microsoft.EntityFrameworkCore;

namespace GameStatisticsVolleball.Models
{
    public class APIDBContext: DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<PlayerMatchStats> PlayerMatchStats { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Tournament> Tournament { get; set; }
        public APIDBContext(DbContextOptions<APIDBContext> options)
            :base(options) { }
        
            
        
    }
}
