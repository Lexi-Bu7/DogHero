using DogHeroApi.Module;
using Microsoft.EntityFrameworkCore;

namespace DogHeroApi.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Dog> Dogs { get; set; }

    }
}
