using Application.Dto;
using System.ComponentModel.DataAnnotations;

namespace Application.Model
{
    public class MetaData
    {
        public List<PointState> pointState { get; set; }
        public List<EventType> eventTypes { get; set; }
        public List<TransactionType> transactionTypes { get; set; }

    }
    public class PointState
    {
        public int id { get; set; }
        public string title { get; set; }
    }
    public class EventType
    {
        public int id { get; set; }
        public string title { get; set; }
    }
    public class TransactionType
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}
