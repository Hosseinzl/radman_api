using Application.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [Authorize]
        [HttpGet("Profile")]
        [ProducesResponseType(200, Type = typeof(Model.Profile))]
        public IActionResult Profile()
        {

            var token = HttpContext.Request.Headers["Authorization"];
            var profile = _profileRepository.GetProfile(token);

            return Ok(profile);
        }
    }
}
