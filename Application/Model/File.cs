using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Model
{
    public class File
    {
        public int id { get; set; }
        public string fileName { get; set; }
        public byte[] content { get; set; }
    }
}
