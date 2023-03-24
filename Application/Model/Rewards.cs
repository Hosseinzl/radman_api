namespace Application.Model
{
    public class Rewards
    {
        public int totalCount { get; set; }
        public List<Reward> rewards {get; set;}
    }

    public class Reward
    {
        public string id { get; set; }
        public string categoryId { get; set; }
        public string title { get; set; }
        public string miniDescription { get; set; }
        public bool isFavorite { get; set; }
        public string imageUrl { get; set; }
        public int point { get; set; }
        public DateTime createdDate { get; set; }
        public int sellCount { get; set; }
    }
}
