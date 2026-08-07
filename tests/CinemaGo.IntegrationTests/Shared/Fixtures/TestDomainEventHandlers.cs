using CinemaGo.Domain;

namespace CinemaGo.IntegrationTests.Shared.Fixtures
{
    public sealed class MoviePromotedToNowShowingHandler(TestDomainEventHandlerProbe probe)
    {
        public Task Handle(MoviePromotedToNowShowing domainEvent)
        {
            probe.MarkHandled(domainEvent);
            return Task.CompletedTask;
        }
    }
}
