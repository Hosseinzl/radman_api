using Application.interfaces;
using Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitionController : Controller
    {
        private readonly ICompetitionRepository _competitionRepository;

        public CompetitionController(ICompetitionRepository competitionRepository)
        {
            _competitionRepository = competitionRepository;
        }

        //[Authorize]
        [HttpGet("GetAllCompetition")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Competition>))]
        [ProducesResponseType(400)]
        public IActionResult GetCompetitions()
        {
            var competitions = _competitionRepository.GetCompetitions();
            if (competitions == null)
            {
                return BadRequest();
            }

            return Ok(competitions);
        }
    }
}
