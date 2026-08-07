using CinemaGo.Domain;

namespace CinemaGo.Infrastructure.Persistence
{
    public class CustomerRepository(AppDbContext db) : BaseRepository<Customer>(db), ICustomerRepository
    {
    }
}
