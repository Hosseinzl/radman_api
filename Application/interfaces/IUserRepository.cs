using Application.Model;

namespace Application.interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        string GetUserOTP(string nationalCode);
        DateTime GetUserOTPExpireTime(string nationalCode);
        bool SaveOTP(string nationalCode, string otp);
        bool SaveToken(string nationalCode, string token);
        bool UserExists(string currentNationalCode);
        bool UserExistsByMobileNumber(string moblieNumber);
        bool UserCreate(User user);
        bool Save();
    }
}
