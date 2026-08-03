namespace CinemaGo.Domain.Abstraction
{
    public abstract class BaseEntity: IEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    }
}
