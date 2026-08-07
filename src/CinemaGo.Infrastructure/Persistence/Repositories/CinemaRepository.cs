using CinemaGo.Domain;

namespace CinemaGo.Infrastructure.Persistence
{
    public class CinemaRepository(AppDbContext db) : BaseRepository<Cinema>(db), ICinemaRepository
    {
    }
}
