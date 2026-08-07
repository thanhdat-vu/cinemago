using CinemaGo.Domain.Abstractions;

namespace CinemaGo.Domain
{
    public interface IAuditableEntity : IDefaultEntity, ITrackable, ISoftDeletable
    {
    }
}
