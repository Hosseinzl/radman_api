using Application.Model;

namespace Application.interfaces
{
    public interface IProfileRepository
    {
        Profile GetProfile(string token);
    }
}
