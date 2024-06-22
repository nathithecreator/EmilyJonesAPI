using EmilyJonesBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmilyJonesBackend.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {

        }

        public DbSet<Product> Furnitures { get; set; }

    }
}
