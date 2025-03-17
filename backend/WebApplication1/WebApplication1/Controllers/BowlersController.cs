using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BowlersController> _logger;

        public BowlersController(IUnitOfWork unitOfWork, ILogger<BowlersController> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/Bowlers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bowler>>> GetBowlers()
        {
            try
            {
                _logger.LogInformation("Getting bowlers from Marlins and Sharks teams");
                var bowlers = await _unitOfWork.Bowlers.GetBowlersByTeamNamesAsync(new[] { "Marlins", "Sharks" });
                return Ok(bowlers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving bowlers");
                return StatusCode(500, "An error occurred while retrieving bowlers");
            }
        }

        // GET: api/Bowlers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bowler>> GetBowler(int id)
        {
            try
            {
                _logger.LogInformation($"Getting bowler with ID: {id}");
                var bowler = await _unitOfWork.Bowlers.GetBowlerWithTeamAsync(id);

                if (bowler == null)
                {
                    _logger.LogWarning($"Bowler with ID: {id} not found");
                    return NotFound();
                }

                // Check if bowler is from Marlins or Sharks team
                if (bowler.Team.TeamName != "Marlins" && bowler.Team.TeamName != "Sharks")
                {
                    _logger.LogWarning($"Bowler with ID: {id} is not from Marlins or Sharks team");
                    return NotFound();
                }

                return bowler;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving bowler with ID: {id}");
                return StatusCode(500, "An error occurred while retrieving the bowler");
            }
        }
    }
}
