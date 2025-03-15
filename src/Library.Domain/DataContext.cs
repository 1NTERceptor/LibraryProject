using Abstracts.Repository;
using Library.Domain.Aggregates;
using Library.Domain.Aggregates.Borrow;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain
{
    public interface IDataContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
    }

    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Borrow> Borrows { get; set; }

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

            modelBuilder.Entity<Borrow>()
                .Property(b => b.Key)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Borrow>(borrow =>
            {
                borrow.HasKey(b => b.Key);

                // Relacja do Guest
                borrow.HasOne<Person>()
                    .WithMany()
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relacja do Book
                borrow.HasOne<Borrow>()
                    .WithMany()
                    .HasForeignKey(b => b.BookId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
