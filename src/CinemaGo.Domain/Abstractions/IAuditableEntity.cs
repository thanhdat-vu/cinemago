namespace CinemaGo.Domain
{
    public interface IAuditableEntity : IDefaultEntity, IAuditable, ISoftDeletable
    {
    }
}
