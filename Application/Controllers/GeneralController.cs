using Application.interfaces;
using Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneralController : Controller
    {
        private readonly IGeneralRepository _generalRepository;
        public GeneralController(IGeneralRepository generalRepository)
        {
            _generalRepository = generalRepository;
        }

        //[Authorize]
        [HttpGet("GetAllGrades")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Grade>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllGrades()
        {
            var grades = _generalRepository.GetAllGrades();

            if (grades == null)
            {
                return BadRequest();
            }

            return Ok(grades);
        }
    }
}
