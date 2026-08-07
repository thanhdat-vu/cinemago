using CinemaGo.Infrastructure.Persistence;
using CinemaGo.IntegrationTests.Shared.Fixtures;

namespace CinemaGo.IntegrationTests.InfrastructureTests.PersistenceTests
{
    [Collection(DatabaseCollection.Name)]
    public abstract class RepositoryTestBase(PostgresContainerFixture databaseFixture)
    {
        protected PostgresContainerFixture DatabaseFixture { get; } = databaseFixture;

        protected AppDbContext CreateDbContext() => DatabaseFixture.CreateDbContext();
    }
}
