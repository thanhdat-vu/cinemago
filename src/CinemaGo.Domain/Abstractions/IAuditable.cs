namespace CinemaGo.Domain
{
    public interface IAuditable
    {
        DateTimeOffset? UpdatedAt { get; set; }
        string? UpdatedBy { get; set; }
        string? CreatedBy { get; set; }
    }
}
