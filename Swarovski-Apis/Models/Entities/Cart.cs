using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swarovski_Apis.Models.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalPrice => Quantity * Price;

        // Many-to-many relationship with Jewel
        public ICollection<CartJewel> CartJewels { get; set; }
    }
}
