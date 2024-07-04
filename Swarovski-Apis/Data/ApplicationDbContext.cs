using Microsoft.EntityFrameworkCore;
using Swarovski_Apis.Models.Entities;

namespace Swarovski_Apis.Data
{
    //DbContext is a base class inherited from entity framowork core that is allows one 
    //to connect to database and allows you to query and save instances of entities
    public class ApplicationDbContext: DbContext
    {
        private object cj;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Jewel> Jewels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartJewel> CartJewels { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //configuring relationship from CartJewel to Cart
            modelBuilder.Entity<CartJewel>()
                .HasOne(cj => cj.Cart)
                .WithMany(c => c.CartJewels)
                .HasForeignKey(cj => cj.CartId);

            //configuring relationship from CartJewel to Jewel
            modelBuilder.Entity<CartJewel>()
                .HasOne(cj => cj.Jewel)
                .WithMany(c => c.CartJewels)
                .HasForeignKey(cj => cj.JewelId);

            modelBuilder.Entity<Cart>().HasData(
            new Cart
             {
               Id = 1,
               UserId = 1, 
               Quantity = 1,
               Price = 0, 
             },
             new Cart
             {
                 Id = 2,
                 UserId = 3,
                 Quantity = 5,
                 Price = 0,
             },
              new Cart
              {
                  Id = 3,
                  UserId = 1,
                  Quantity = 3,
                  Price = 0,
              }


                );
        }
    }
}
