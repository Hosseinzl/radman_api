using Application.Dto;
using Application.interfaces;
using Application.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //[Authorize]
        [HttpGet("GetUsers")]
        [ProducesResponseType(200, Type = typeof(ICollection<User>))]
        //[ProducesResponseType(400)]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(users);
        }

        //[Authorize]
        [HttpPost("CreateUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UserCreate(UserDto postedUser)
        {
            if (postedUser == null)
                return BadRequest(ModelState);
            if (_userRepository.UserExists(postedUser.nationalCode))
            {
                ModelState.AddModelError("", "User Exists");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _mapper.Map<User>(postedUser);
            
            if (!_userRepository.UserCreate(user))
            {
                ModelState.AddModelError("", "Something went wrong saving the record");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully created");

        }
    }
}
