using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CinemaGo.Infrastructure.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__cinemagodb")
                ?? Environment.GetEnvironmentVariable("POSTGRES_CONNECTION")
                ?? "Host=localhost;Port=5432;Database=cinemagodb;Username=postgres;Password=postgres";

            optionsBuilder.UseNpgsql(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

// Add-Migration MigrationName -OutputDir Persistence/Migrations