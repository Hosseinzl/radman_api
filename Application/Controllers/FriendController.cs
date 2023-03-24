using Application.interfaces;
using Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("id/[controller]")]
    public class FriendController : Controller
        
    {
        private readonly IFriendsRepository _friendsRepository;
        private readonly IUserRepository _userRepository;

        public FriendController(IFriendsRepository friendsRepository, IUserRepository userRepository)
        {
            _friendsRepository = friendsRepository;
            _userRepository = userRepository;
        }


        //[Authorize]
        [HttpGet("InvitationList")]
        [ProducesResponseType(200, Type = typeof(Friends))]
        public IActionResult GetInvitationList()
        {
            var friend = _friendsRepository.GetInvitationList();
            return Ok(friend);

        }

        //[Authorize]
        [HttpPost("SendInvitation")]
        public IActionResult SendInvitation([FromBody] SendInvitation sendInvitation)
        {
            if (sendInvitation == null) { 
                return BadRequest(ModelState);
            }

            if (!_userRepository.UserExistsByMobileNumber(sendInvitation.mobile))
            {
                ModelState.AddModelError("", "there is not any user with this information");
                return StatusCode(404, ModelState);
            }

            if (_friendsRepository.ExistsInvitation(sendInvitation.mobile))
            {
                ModelState.AddModelError("", "you have already sent an invitation to this user");
                return StatusCode(404, ModelState);
            }
            
            if (!_friendsRepository.SendInvitation(sendInvitation))
            {
                ModelState.AddModelError("", "something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("successfully sent");
        }
    }
}
