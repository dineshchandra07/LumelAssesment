using Microsoft.EntityFrameworkCore;

namespace LumelAssesment.DataAccess
{
    public class LumelDbContext: DbContext
    {
       public LumelDbContext(DbContextOptions<LumelDbContext> options): base(options){ }
        public DbSet<Models.Orders> Orders { get; set; }
        public DbSet<Models.Products> Products { get; set; }
        public DbSet<Models.Customers> Customers { get; set; }
        public DbSet<Models.CSVData> OrderHistory { get; set; }
    }
}
