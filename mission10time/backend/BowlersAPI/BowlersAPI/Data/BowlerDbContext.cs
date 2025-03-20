using Microsoft.EntityFrameworkCore;

namespace BowlersAPI.Data
{
    public class BowlerDbContext : DbContext
    {
        public BowlerDbContext(DbContextOptions<BowlerDbContext> options) : base(options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; }
    }
}
