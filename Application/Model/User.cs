namespace Application.Model
{
    public class User
    {
        public int id { get; set; }
        public string nationalCode { get; set; }
        public string otp { get; set; }
        public string token { get; set; }
        public DateTime otpExpireDate { get; set; }
        public string mobileNumber { get; set; }
        public Profile profile { get; set; }
    }
}
