using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swarovski_Apis.Models.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        //foreign key
        public int JewelId { get; set; }
        public Jewel Jewel { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string JewelName { get; set; }
        public string JewelImage { get; set; }

    }
}
