using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Repositories
{
    public class BowlerRepository : Repository<Bowler>, IBowlerRepository
    {
        public BowlerRepository(BowlingLeagueContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Bowler>> GetBowlersWithTeamAsync()
        {
            return await Context.Bowlers
                .Include(b => b.Team)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bowler>> GetBowlersByTeamNamesAsync(string[] teamNames)
        {
            return await Context.Bowlers
                .Include(b => b.Team)
                .Where(b => teamNames.Contains(b.Team.TeamName))
                .OrderBy(b => b.Team.TeamName)
                .ThenBy(b => b.BowlerLastName)
                .ThenBy(b => b.BowlerFirstName)
                .ToListAsync();
        }

        public async Task<Bowler> GetBowlerWithTeamAsync(int id)
        {
            return await Context.Bowlers
                .Include(b => b.Team)
                .FirstOrDefaultAsync(b => b.BowlerID == id);
        }
    }
}
