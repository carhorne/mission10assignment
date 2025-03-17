using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class BowlingLeagueContext : DbContext
    {
        public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
            : base(options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships
            modelBuilder.Entity<Bowler>()
                .HasOne(b => b.Team)
                .WithMany(t => t.Bowlers)
                .HasForeignKey(b => b.TeamID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure indexes
            modelBuilder.Entity<Bowler>()
                .HasIndex(b => b.BowlerLastName)
                .HasDatabaseName("BowlerLastName");

            modelBuilder.Entity<Bowler>()
                .HasIndex(b => b.TeamID)
                .HasDatabaseName("BowlersTeamID");

            modelBuilder.Entity<Team>()
                .HasIndex(t => t.TeamID)
                .HasDatabaseName("TeamID")
                .IsUnique();
        }
    }
}
