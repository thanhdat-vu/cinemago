using CinemaGo.Domain;

namespace CinemaGo.Infrastructure.Persistence
{
    public class ScreenRepository(AppDbContext db) : BaseRepository<Screen>(db), IScreenRepository
    {
    }
}
