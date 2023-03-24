using Application.interfaces;
using Application.Model;
using Application.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnOverController : Controller
    {

        private readonly ITurnOverRepository _turnOverRepository;
        public TurnOverController(ITurnOverRepository turnOverRepository)
        {
            _turnOverRepository = turnOverRepository;
        }

        //[Authorize]
        [HttpGet("GetMetaData")]
        [ProducesResponseType(200, Type = typeof(MetaData))]
        public IActionResult GetMetaData()
        {
            var metaData = _turnOverRepository.GetMetaData();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return Ok(metaData);
        
        }

        //[Authorize]
        [HttpGet("GetTurnOvers")]
        [ProducesResponseType(200, Type = typeof(AllTurnOver))]
        public IActionResult GetTurnOvers([FromQuery] DateTime fromDate,
            [FromQuery] DateTime toDate,
            [FromQuery] int transactionType,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var turnOvers = _turnOverRepository.GetTurnOvers(fromDate, toDate, transactionType, page, pageSize);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return Ok(turnOvers);
            
        }
    }
}
