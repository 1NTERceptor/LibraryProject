using Abstracts.Repository;
using Library.Domain.Aggregates;
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
            .HasKey(b => b.Key);

            modelBuilder.Entity<Loan>(l =>
            {
                l.HasKey(b => b.Key);

                l.HasOne(l => l.User)
                 .WithMany(u => u.Loans)
                 .HasForeignKey(l => l.UserId);

                l.HasOne(l => l.Book)
                 .WithOne(b => b.Loan)
                 .HasForeignKey<Loan>(l => l.BookId);
            });
        }
    }
}
