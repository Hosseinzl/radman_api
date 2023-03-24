using Application.Data;
using Application.interfaces;
using Application.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Application.Repository
{
    public class FriendsRepository : IFriendsRepository
    {
        private readonly DataContext _dataContext;

        public FriendsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public Friends GetInvitationList()
        {
            return _dataContext.friends.Include(f => f.friendInvitations).Include(f => f.invitationStatistics).FirstOrDefault();
        }

        public bool SendInvitation(SendInvitation sendInvitation)
        {

             var id = _dataContext.friends.FirstOrDefault().id;
               
             var invitation = new FriendInvitation
             {
                 UserId = id,
                 isMale = sendInvitation.isMale,
                 moblie = sendInvitation.mobile,
                 state = "waiting",
                 recivedPoint = 0
             };

            _dataContext.invitationStatistics.Where(i => i.idUser == id).FirstOrDefault().totalSentInvitationCount++;
            _dataContext.invitationStatistics.Where(i => i.idUser == id).FirstOrDefault().waitingCount++;
          

            _dataContext.friendInvitations.Add(invitation);
             return Save();
            
        }
        
        public bool Save()
        {
            var save = _dataContext.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool ExistsInvitation(string mobileNumber)
        {
            var id = _dataContext.friends.FirstOrDefault().id;
            return _dataContext.friendInvitations.Any(i => i.UserId == id && i.moblie == mobileNumber && i.state != "rejected");
        }
    }
}
