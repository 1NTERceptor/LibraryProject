using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace Abstracts.Repository
{
    public interface IDbContext : IDataContextBase
    {
        ChangeTracker ChangeTracker { get; }
    }

    public class ApplicationDbContext : DbContext, IDataContextBase, IDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public new DbSet<T> Set<T>() where T : class => base.Set<T>();

        public ChangeTracker ChangeTracker => base.ChangeTracker;

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
