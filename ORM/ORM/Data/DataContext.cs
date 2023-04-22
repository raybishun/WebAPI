using Microsoft.EntityFrameworkCore;

namespace ORM.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            // Had to create a default ctor to resolve the below error when running:

            // "dotnet ef migrations add InitialCreate"

            // Unable to create an object of type 'DataContext'.
            // For the different patterns supported at design time,
            // see https://go.microsoft.com/fwlink/?linkid=851728
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=OrmDb;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<WeatherForecast> Forecasts { get; set; }

        // TODO
        // cd actual project directory
        // dotnet ef migrations add InitialCreate
        // dotnet ef database update


        // https://learn.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli
    }
}
