using Microsoft.EntityFrameworkCore;
namespace ShopThoiTrang.API.Data
{

    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) {}


    public DbSet<SanPhams> SanPhams { get; set; }
}
   
 }  

