using System.Text.Json.Serialization;
using System.Xml.Schema;

namespace Application.Model
{
    public class AllTurnOver
    {
        public AllTurnOver()
        {
            turnOverReport = new TurnOverReport();
            turnOvers = new List<TurnOvers>();
        }
        
        public int totalIncome { get; set; }
        public int totalOutcome { get; set; }
        public List<TurnOvers> turnOvers { get; set; }
        public TurnOverReport turnOverReport {get; set;}
        public int totalCount { get; set; }
    }

    public class TurnOverBase
    {
        [JsonPropertyOrder(-4)]
        public string id { get; set; }
        [JsonPropertyOrder(-3)]
        public string title { get; set; }
        [JsonPropertyOrder(-2)]
        public DateTime date { get; set; }
        [JsonPropertyOrder(-1)]
        public int point { get; set; }

    }
    public class TurnOvers : TurnOverBase
    {
        public TransactionType transactionType { get; set; }
        public EventType eventType { get; set; }
        public PointState state { get; set; }
    }

    public class TurnOverDataBase : TurnOverBase
    {
        public int transactionType { get; set; }
        public int eventType { get; set; }
        public int state { get; set; }
    }


    public class Report
    {
        public string title { get; set; }
        public int point { get; set; }
        public int percentage { get; set; }
    }
    
    public class TurnOverReport
    {
        public TurnOverReport()
        {
            income = new List<Report>();
            outcome = new List<Report>();
        }
        public List<Report> income { get; set; }
        public List<Report> outcome { get; set; }
    }
    
}
