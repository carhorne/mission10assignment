using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace WebApplication1.Repositories
{
    public interface IBowlerRepository : IRepository<Bowler>
    {
        Task<IEnumerable<Bowler>> GetBowlersWithTeamAsync();
        Task<IEnumerable<Bowler>> GetBowlersByTeamNamesAsync(string[] teamNames);
        Task<Bowler> GetBowlerWithTeamAsync(int id);
    }
}
