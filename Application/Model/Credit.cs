using System.ComponentModel.DataAnnotations;

namespace Application.Model
{
    public class Credit
    {
        public int id { get; set; }
        public GeneralInfo generalInfo { get; set; }
        public List<PortfoloItems> portfoloItems { get; set; }
        public List<PortfoloItems> top5Items { get; set; }
        
    }
    
    public class GeneralInfo
    {
        public int generalInfoId { get; set; }
        public int creditId { get; set; }
        public int totalCash { get; set; }
        public int totalAsset { get; set; }
        public int totalStock { get; set; }
        public int remainingDays { get; set; }
    }
    public class PortfoloItems
    {
        public int portfoloItemId { get; set; }
        public int idOfCredit { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int value { get; set; }
    }
}
