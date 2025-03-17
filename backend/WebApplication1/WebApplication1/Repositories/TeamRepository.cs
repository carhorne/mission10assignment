using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(BowlingLeagueContext context)
           : base(context)
        {
        }

        public async Task<Team> GetTeamWithBowlersAsync(int id)
        {
            return await Context.Teams
                .Include(t => t.Bowlers)
                .FirstOrDefaultAsync(t => t.TeamID == id);
        }

        public async Task<Team> GetTeamByNameAsync(string name)
        {
            return await Context.Teams
                .FirstOrDefaultAsync(t => t.TeamName == name);
        }
    }
}
