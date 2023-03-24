using Application.interfaces;
using Application.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RewardController : Controller
    {
        private readonly IRewardRepository _rewardRepistory;

        public RewardController(IRewardRepository rewardRepistory)
        {
            _rewardRepistory = rewardRepistory;
        }


        //[Authorize]
        [HttpGet("GetAllCategories")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllCategories()
        {
            var categories = _rewardRepistory.GetAllCategories();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(categories);
        }

        //[Authorize]
        [HttpGet("GetRewardList")]
        [ProducesResponseType(200, Type =(typeof(Rewards)))]
        [ProducesResponseType(400)]
        public IActionResult GetRewardList(
            [FromQuery] int max,
            [FromQuery] string categoriesId,
            [FromQuery] int pageSize = 20,
            [FromQuery] int page = 1,
            [FromQuery][EnumDataType(typeof(SortOptions))] int? sort = null,
            [FromQuery] bool isFavorite = false,
            [FromQuery] int min = 0)
        {
            if (categoriesId == null)
            {
                return BadRequest(ModelState);
            }

            var rewards = _rewardRepistory.GetRewardList(max, categoriesId, pageSize, page, sort, isFavorite, min);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return Ok(rewards);
        }

        //[Authorize]
        [HttpGet("GetSortTypes")]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<SortType>)))]
        [ProducesResponseType(400)]
        public IActionResult GetSortTypes()
        {
            var sortTypes = _rewardRepistory.GetSortTypes();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(sortTypes);
        }

        //[Authorize]
        [HttpGet("Like")]
        [ProducesResponseType(200, Type = (typeof(Response)))]
        public IActionResult Like()
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        //[Authorize]
        [HttpGet("DisLike")]
        [ProducesResponseType(200, Type = (typeof(Response)))]
        public IActionResult DisLike()
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        //[Authorize]
        [HttpGet("GetRewardDetails")]
        [ProducesResponseType(200, Type = (typeof(RewardDetail)))]
        [ProducesResponseType(400)]
        public IActionResult GetRewardDetails([FromQuery] string rewardId)
        {
            if (rewardId == null)
            {
                return BadRequest();
            }

            var rewardDetail = _rewardRepistory.GetRewardDetails(rewardId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(rewardDetail);

        }

        //[Authorize]
        [HttpPost("Buy")]
        public IActionResult Buy([FromQuery] int count, [FromQuery] string rewardId )
        {
            if (count == 0 || rewardId == null)
            {
                return BadRequest();
            }

            if (!_rewardRepistory.ExistsReward(rewardId))
            {
                ModelState.AddModelError("", "Reward not found");
                return StatusCode(500, ModelState);
            }
            
            var token = Request.Headers["Authorization"];

            if (!_rewardRepistory.Buy(count, rewardId, token))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully added");
        }
    }

    public enum SortOptions
    {
        None = 1,
        Ascending = 2,
        Descending = 3
    }

    public class Response
    {
        public bool isSuccessful { get; set; }
        public string message { get; set; }
    }
}
