namespace Application.Model
{
    public class Grade
    {
        public string id { get; set; }
        public string name { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public bool isMaxInfinity { get; set; }
        public string colorHex { get; set; }
    }
}

