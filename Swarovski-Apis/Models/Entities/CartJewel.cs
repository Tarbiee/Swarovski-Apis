using System.ComponentModel.DataAnnotations;

namespace Swarovski_Apis.Models.Entities
{
    public class CartJewel
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int JewelId { get; set; }
        public Jewel Jewel { get; set; }
    }
}
