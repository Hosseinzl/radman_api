using Application.Data;
using Application.interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public AuthenticationRepository(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }
        
        public string GetOTP(string nationalCode)
        {
            //Generate Random OTP
            var otp = new Random().Next(100000, 999999).ToString();
            _dataContext.users.FirstOrDefault(x => x.nationalCode == nationalCode).otp = otp;
            return otp;
        }

        public string GetToken()
        {
            var key = Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["jwt:issuer"],
                _configuration["jwt:audience"],
                null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
