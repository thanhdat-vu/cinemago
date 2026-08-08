namespace CinemaGo.Domain
{
    public interface IAuditableEntity : IDefaultEntity, ITrackable, ISoftDeletable
    {
    }
}
