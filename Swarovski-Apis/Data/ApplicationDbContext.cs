using Microsoft.EntityFrameworkCore;
using Swarovski_Apis.Models.Entities;

namespace Swarovski_Apis.Data
{
    //DbContext is a base class inherited from entity framowork core that is allows one 
    //to connect to database and allows you to query and save instances of entities
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Jewel> Jewels { get; set; }
    }
}
