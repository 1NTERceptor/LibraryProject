using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace Abstracts.Repository
{
    public interface IDataContextBase  
    {
        DbSet<T> Set<T>() where T : class;
        void SaveChanges();
        Task SaveChangesAsync();
        ChangeTracker ChangeTracker { get; }
    }
}
