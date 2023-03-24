namespace Application.Model
{
    public class Profile
    {
        public string Id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public PointInfo pointInfo { get; set; }
    }
    
    public class PointInfo
    {
        public string pointId { get; set; }
        public string profileId { get; set; }
        public int point { get; set; }
        public int pointsToLevel { get; set; }
        public string activeLevel { get; set; }
        public int activeLevelPercentage { get; set; }
    }
}
