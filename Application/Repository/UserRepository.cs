using Application.Data;
using Application.interfaces;
using Application.Model;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _datacontext;

        public UserRepository(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public ICollection<User> GetUsers()
        {
            return _datacontext.users.Include(u => u.profile).Include(u => u.profile.pointInfo).ToList();
        }

        public string GetUserOTP(string nationalCode)
        {
            return _datacontext.users.Where(u => u.nationalCode == nationalCode).Select(u => u.otp).FirstOrDefault();
            
        }

        public bool UserCreate(User user)
        {
            user.otp = "";
            user.otpExpireDate = DateTime.Now;
            user.token = "";
            _datacontext.users.Add(user);
            return Save();
        }

        public bool Save()
        {
            var save = _datacontext.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UserExists(string currentNationalCode)
        {
            return _datacontext.users.Any(u => u.nationalCode == currentNationalCode);
        }

        public bool SaveOTP(string nationalCode, string otp)
        {
            var user = _datacontext.users.Where(u => u.nationalCode == nationalCode).FirstOrDefault();
            user.otp = otp;
            user.otpExpireDate = DateTime.Now.AddMinutes(1);
            return Save();
        }

        public DateTime GetUserOTPExpireTime(string nationalCode)
        {
            return _datacontext.users.Where(u => u.nationalCode == nationalCode).Select(u => u.otpExpireDate).FirstOrDefault();
        }

        public bool UserExistsByMobileNumber(string moblieNumber)
        {
            return _datacontext.users.Any(u => u.mobileNumber == moblieNumber);
        }

        public bool SaveToken(string nationalCode, string token)
        {
            var user = _datacontext.users.Where(u => u.nationalCode == nationalCode).FirstOrDefault();
            user.token = "Bearer " + token;
            return Save();
        }
    }
}
