﻿using Abstracts.Repository;
using Library.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.Domain
{
    public interface IDataContext : IDataContextBase
    {
        public DbSet<Person> Persons { get; set; }
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

        public DbSet<Person> Persons { get; set; }

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
            modelBuilder.Entity<Person>( p=>
            {
                p.HasKey(p => p.Key);
                p.HasDiscriminator<string>("Type")
                    .HasValue<Worker>("Worker")
                    .HasValue<User>("User");
                p.Property(p => p.FirstName).IsRequired();
                p.Property(p => p.LastName).IsRequired();
                p.Property(p => p.Login).IsRequired();
            });

            modelBuilder.Entity<User>()
                .Property(u => u.GuestCardNumber).IsRequired();

            modelBuilder.Entity<Worker>()
                .Property(p => p.EmployeeCardNumber).IsRequired();

            modelBuilder.Entity<Book>(b=>
            {
                b.HasKey(b => b.Key);
                b.Property(b => b.Title).IsRequired();
                b.Property(b => b.Author).IsRequired();
                b.Property(b => b.ReleaseDate).IsRequired();
            });

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
