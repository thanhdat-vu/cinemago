using CinemaGo.Domain;

namespace CinemaGo.Infrastructure.Persistence
{
    public class ConcessionRepository(AppDbContext db) : BaseRepository<Concession>(db), IConcessionRepository
    {
    }
}
