using CinemaGo.Infrastructure.Persistence;
using CinemaGo.IntegrationTests.Shared.DataSeeders;
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;

namespace CinemaGo.IntegrationTests.Shared.Fixtures
{
    public sealed class PostgresContainerFixture : IAsyncLifetime
    {
        private readonly PostgreSqlContainer _postgresContainer = new PostgreSqlBuilder("postgres:17")
            .WithDatabase("cinema_ticket_booking_it")
            .WithUsername("postgres")
            .WithPassword("postgres")
            .WithCleanUp(true)
            .Build();

        public string ConnectionString => _postgresContainer.GetConnectionString();

        public async Task InitializeAsync()
        {
            await _postgresContainer.StartAsync();

            await using var dbContext = CreateDbContext();
            await dbContext.Database.MigrateAsync();
        }

        public async Task DisposeAsync()
        {
            await _postgresContainer.DisposeAsync();
        }

        public AppDbContext CreateDbContext()
        {
            return TestDbContextFactory.Create(ConnectionString);
        }

        public Task ResetDatabaseAsync(CancellationToken ct = default)
        {
            return DatabaseReset.ResetAsync(ConnectionString, ct);
        }
    }
}
