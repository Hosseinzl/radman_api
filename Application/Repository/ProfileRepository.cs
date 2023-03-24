using Application.Data;
using Application.interfaces;
using Application.Model;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DataContext _dataContext;
        public ProfileRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public Profile GetProfile(string token)
        {
            return _dataContext.users.Where(u => u.token == token).Include(u => u.profile.pointInfo).FirstOrDefault().profile;       
        }
    }
}
