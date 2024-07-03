using System.ComponentModel.DataAnnotations;
namespace Swarovski_Apis.Models.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JewelryId {  get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalPrice => Quantity * Price;
    }
}
