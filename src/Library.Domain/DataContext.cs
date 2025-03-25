using Abstracts.Repository;
using Library.Domain.Aggregates;
using Library.Domain.Aggregates.Loan;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.Domain
{
    public interface IDataContext : IDataContextBase
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public Task SaveChangesAsync();
    }

    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Loan> Loans { get; set; }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasKey(p => p.Key);  

            modelBuilder.Entity<Worker>()
            .HasKey(p => p.Key);

            modelBuilder.Entity<Book>()
            .HasKey(b => b.Id);

            modelBuilder.Entity<Loan>(l =>
            {
                l.HasKey(b => b.Key);

                l.HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(u => u.UserId);

                l.HasOne(l => l.Book)
                .WithOne(b => b.Loan);
            });
        }
    }
}
