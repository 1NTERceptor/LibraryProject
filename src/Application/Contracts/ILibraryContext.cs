using Domain.Aggregates.Books;
using Domain.Aggregates.Loans;
using Domain.Aggregates.Persons;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Repository;

namespace Application.Contracts;

public interface ILibraryContext : IDataContextBase
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }
}