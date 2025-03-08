using Library.Domain.Aggregates;
using Library.Domain.Aggregates.Persons;
using Microsoft.EntityFrameworkCore;

namespace Library.Domain
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<User> Guests { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<GuestBook> GuestBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Person>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("PersonType")
                .HasValue<User>("Guest")
                .HasValue<Worker>("Worker");

            modelBuilder.Entity<GuestBook>()
            .HasKey(gb => new { gb.GuestId, gb.BookId }); // Klucz złożony

            //modelBuilder.Entity<GuestBook>()
            //    .HasOne(gb => gb.Guest)
            //    .WithMany(g => g.BorrowedBooks)
            //    .HasForeignKey(gb => gb.GuestId);

            //modelBuilder.Entity<GuestBook>()
            //    .HasOne(gb => gb.Book)
            //    .WithMany()
            //    .HasForeignKey(gb => gb.BookId);
        }
    }
}
