using System.ComponentModel.DataAnnotations;

namespace Swarovski_Apis.Models.Entities
{
    public class Jewel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string  material{ get; set; }
        public int price { get; set; }


    }
}
