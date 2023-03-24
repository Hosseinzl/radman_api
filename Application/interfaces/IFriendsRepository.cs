using Application.Model;

namespace Application.interfaces
{
    public interface IFriendsRepository
    {
        Friends GetInvitationList();
        bool SendInvitation(SendInvitation sendInvitation);
        bool ExistsInvitation(string mobile);
        bool Save();
    }
}
