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
            //defining composite key
            modelBuilder.Entity<CartJewel>()
                .HasKey(cj => new { cj.CartId, cj.JewelId });

            //configuring relationship from CartJewel to Cart
            modelBuilder.Entity<CartJewel>()
                .HasOne(cj => cj.Cart)
                .WithMany(c => c.CartJewels)
                .HasForeignKey(cj=> cj.CartId);

            //configuring relationship from CartJewel to Jewel
            modelBuilder.Entity<CartJewel>()
                .HasOne(cj => cj.Jewel)
                .WithMany(c => c.CartJewels)
                .HasForeignKey(cj => cj.JewelId);
        }
    }
}
