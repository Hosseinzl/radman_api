namespace Application.Model
{
    public class RewardDetails
    {
        public string id { get; set; }
        public string rewardId { get; set; }
        public string? description { get; set; }
    }
    public class RewardDetail : Reward
    {
        public string? description { get; set; }
    }
}
