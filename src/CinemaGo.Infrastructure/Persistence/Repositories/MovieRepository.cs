using CinemaGo.Domain;

namespace CinemaGo.Infrastructure.Persistence
{
    public class MovieRepository(AppDbContext db) : BaseRepository<Movie>(db), IMovieRepository
    {
    }
}
