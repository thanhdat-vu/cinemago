namespace CinemaGo.Application
{
    public interface ICachableRequest
    {
        string CacheKey { get; }
        TimeSpan? SlidingExpiration { get; }
    }
}
