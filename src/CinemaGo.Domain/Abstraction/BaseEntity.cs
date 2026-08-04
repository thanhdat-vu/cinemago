namespace CinemaGo.Domain
{
    public abstract class BaseEntity: IEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public uint Version { get; set; }

        private readonly List<IDomainEvent> _events = [];
        public IReadOnlyCollection<IDomainEvent> Events => _events.AsReadOnly();

        public void RaiseEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }
    }
}
