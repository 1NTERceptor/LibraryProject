using Library.Domain.Aggregates;
using Library.Domain.Aggregates.Loan;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.Domain
{
    public interface IDataContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public Task SaveChangesAsync();
    }

    public class DataContext : DbContext, IDataContext, Abstracts.Repository.IDataContext
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
            // Ustawienie klucza głównego dla Person w kontekście Worker i User
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Key);  // Person ma klucz główny w klasach dziedziczących

            // Konfiguracja dziedziczenia
            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("PersonType")
                .HasValue<User>("User")
                .HasValue<Worker>("Worker");

            modelBuilder.Entity<Book>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Loan>()
                .Property(b => b.Key)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Loan>(borrow =>
            {
                borrow.HasKey(b => b.Key);

                // Relacja do Guest
                borrow.HasOne<Person>()
                    .WithMany()
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relacja do Book
                borrow.HasOne<Loan>()
                    .WithMany()
                    .HasForeignKey(b => b.BookId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
