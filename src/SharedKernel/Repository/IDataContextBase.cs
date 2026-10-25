using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
