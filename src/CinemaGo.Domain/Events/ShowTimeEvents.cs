namespace CinemaGo.Domain
{
    public record ShowTimeCreated(Guid ShowTimeId, Guid ScreenId) : IDomainEvent;
    public record ShowTimeCancelled(Guid ShowTimeId) : IDomainEvent;
}
