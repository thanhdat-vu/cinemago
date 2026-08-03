namespace CinemaGo.Application
{
    public interface INotificationService
    {
        Task SendAsync(object message, CancellationToken ct = default);
    }
}
