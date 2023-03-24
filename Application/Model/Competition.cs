using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Model
{
    public class Competition
    {
        public string id { get; set; }
        public string title { get; set; }
        public State state { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int competitorCounts { get; set; }
        public int yourPoint { get; set; }
        public int totalCount { get; set; }
        public bool isUserAttend { get; set; }

    }
    public class State
    {
        public int stateId { get; set; }
        public string title { set; get; }
    }

}
