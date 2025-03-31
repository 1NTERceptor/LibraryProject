using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Abstracts.Repository
{
    public interface IDataContextBase
    {
        DbSet<T> Set<T>() where T : class;
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
