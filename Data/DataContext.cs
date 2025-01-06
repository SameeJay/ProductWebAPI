using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Models;

namespace ProductWebAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }

    }
}
