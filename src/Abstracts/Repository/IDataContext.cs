using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Abstracts.Repository
{
    public interface IDataContext
    {
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
