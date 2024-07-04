﻿using System.ComponentModel.DataAnnotations;

namespace Swarovski_Apis.Models.Entities
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }

        public ICollection<Cart> Carts { get; set; }

    }
}
