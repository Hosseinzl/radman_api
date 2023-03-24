namespace Application.Model
{
    public class Friends
    {
        public int id { get; set; }
        public int totalCount { get; set; }
        public ICollection<FriendInvitation> friendInvitations { get; set; }
        public InvitationStatistics invitationStatistics { get; set; }

    }
    
    public class FriendInvitation
    {
        public int invitationId { get; set; }
        public int UserId { get; set; }
        public bool isMale { get; set; }
        public string moblie { get; set; }
        public string state { get; set; }
        public int recivedPoint { get; set; }
    }
    public class InvitationStatistics
    {
        public int invitationStatisticsId { get; set; }
        public int idUser { get; set; }
        public int totalInvitationPoint { get; set; }
        public int acceptedCount { get; set; }
        public int waitingCount { get; set; }
        public int totalSentInvitationCount { get; set; }
    }
    public class SendInvitation
    {
        public bool isMale { get; set; }
        public string mobile { get; set; }
        public string title { get; set; }

    }
}
