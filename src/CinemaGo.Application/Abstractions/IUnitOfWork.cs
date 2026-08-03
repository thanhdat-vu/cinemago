using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaGo.Application
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
