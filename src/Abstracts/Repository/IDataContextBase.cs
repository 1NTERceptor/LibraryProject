using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace SharedKernel.Repository
{
    public interface IDataContextBase  
    {
        DbSet<T> Set<T>() where T : class;
        void SaveChanges();
        Task SaveChangesAsync();
        ChangeTracker ChangeTracker { get; }
    }
}
