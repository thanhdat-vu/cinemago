namespace CinemaGo.Domain.Abstraction
{
    public interface ISoftDeletable
    {
        DateTimeOffset? DeletedAt { get; set; }
        bool IsDeleted { get; }
    }
}
