using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        // Prerequisites (from PM Console)
        // dotnet ef
        // dotnet tool install --global dotnet-ef
        // dotnet ef --version

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
