using BowlersAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BowlersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private BowlerDbContext _bowlerContext;

        public BowlerController(BowlerDbContext temp) 
        {
            _bowlerContext = temp;
        }


        [HttpGet(Name = "GetBowler")]
        public IEnumerable<Bowler> Get()
        {
            var bowlerList = _bowlerContext.Bowlers
                                .Where(b => b.TeamID == 1 || b.TeamID == 2)
                                .ToList();

            return bowlerList;
        }
    }
}
