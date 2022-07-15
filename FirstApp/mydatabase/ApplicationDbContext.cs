using FirstApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.mydatabase
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Catagory>Catagories { get; set; }
    }
}
