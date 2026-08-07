using CinemaGo.Domain;

namespace CinemaGo.Infrastructure.Persistence
{
    public class TicketRepository(AppDbContext db) : BaseRepository<Ticket>(db), ITicketRepository
    {
    }
}
