using CinemaGo.Application;

namespace CinemaGo.IntegrationTests.Shared.Fixtures
{
    public sealed class FakeUserContext : IUserContext
    {
        public Guid UserId { get; } = Guid.CreateVersion7();
        public string UserName { get; } = "integration-tester";

        public bool IsInRole(string role)
        {
            return string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase);
        }
    }
}
