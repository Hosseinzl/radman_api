using Application.Model;

namespace Application.Dto
{
    public class UserDto
    {
        public int id { get; set; }
        public string nationalCode { get; set; }
        public string mobileNumber { get; set; }
        public Profile profile { get; set; }

    }
}
