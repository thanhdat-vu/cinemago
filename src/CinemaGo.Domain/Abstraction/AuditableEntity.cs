namespace CinemaGo.Domain
{
    public abstract class AuditableEntity : BaseEntity, ISoftDeletable
    {
        public string? CreatedBy { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public bool IsDeleted => DeletedAt.HasValue;
    }
}
