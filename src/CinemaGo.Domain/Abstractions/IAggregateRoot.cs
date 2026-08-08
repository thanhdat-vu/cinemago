namespace CinemaGo.Domain.Abstractions
{
    public interface IAggregateRoot : IDefaultEntity, IAuditable, ISoftDeletable
    {
    }
}
