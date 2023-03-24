using Application.interfaces;
using Application.Model;
using Application.Repository;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly ICaptchaRepository _captchaRepository;
        private readonly IDistributedCache _cache;
        public AuthenticationController(IUserRepository userRepository, IAuthenticationRepository authenticationRepository, ICaptchaRepository captchaRepository , IDistributedCache cache)
        {
            _userRepository = userRepository;
            _authenticationRepository = authenticationRepository;
            _captchaRepository = captchaRepository;
            _cache = cache;
        }

        [HttpGet("GetCaptchaImage")]
        [ProducesResponseType(200, Type = typeof(Captcha))]
        public IActionResult GetCapthcaImage()
        {
            var captcha = _captchaRepository.GetCapthcaImage();

            _cache.SetString(captcha.captchaKey, captcha.captchaKey, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            });

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(captcha);
        }

        [HttpPost("RequestOTP")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult RequestOtp([FromBody] RequestOTP request)
        {
            if (request == null)
            {
                return BadRequest(ModelState);
            }


            string captchaKey = _cache.GetString(request.captchaKey);

            if (captchaKey == null)
            {
                return BadRequest(new ObjectResult(new
                {
                    message = "کپچا اشتباه است",
                    errorCode = 4001
                }));

            }

            _cache.Remove(request.captchaKey);
          
            if (!_userRepository.UserExists(request.nationalCode))
            {
                return BadRequest(new ObjectResult(new
                {
                    message = "کد ملی اشتباه است",
                    errorCode = 4001
                }));
            }

            // return random otp
            var otp = _authenticationRepository.GetOTP(request.nationalCode);
            
            if (!_userRepository.SaveOTP(request.nationalCode, otp))
            {
                return BadRequest(new ObjectResult(new
                {
                    message = "there is some thing wrong while save otp"
                }));
            }

            

            return Ok(new ObjectResult(new
            {
                OTP = otp,
                message = "success"
            }));

        }

        [HttpPost("VerifyOTP")]
        [ProducesResponseType(204)]
        public IActionResult VerifyOTP(VerifyOTP verifyOtp)
        {
            if (verifyOtp == null)
            {
                return BadRequest(ModelState);
            }

            string captchaKey = _cache.GetString(verifyOtp.captchaKey);

            if (captchaKey == null)
            {
                return BadRequest(new ObjectResult(new
                {
                    message = "کپچا اشتباه است",
                    errorCode = 4001
                }));
            }

            _cache.Remove(verifyOtp.captchaKey);

            var otp = _userRepository.GetUserOTP(verifyOtp.nationalCode);
            var expireTime = _userRepository.GetUserOTPExpireTime(verifyOtp.nationalCode);
            if (verifyOtp.otp != otp || expireTime < DateTime.Now)
            {
                return BadRequest(new ObjectResult(new
                {
                    message = "رمز معتبر نیست"
                }));
            }

            var tokenValue = _authenticationRepository.GetToken();

            if (!_userRepository.SaveToken(verifyOtp.nationalCode, tokenValue))
            {
                return BadRequest(new ObjectResult(new
                {
                    message = "there is some thing wrong while save token"
                }));
            }

            return Ok(new ObjectResult(new
            {
                token = tokenValue,
                message = "token successfully generated"
            }));

        }


    }
}
