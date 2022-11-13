using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.Infrastructure.EFCore.UnitOfWork;

public class AuthorUnitOfWork : GenericUnitOfWork, IAuthorUnitOfWork
{
    private IRepository<Author>? _authorRepository;
    private IRepository<Book>? _bookRepository;

    public AuthorUnitOfWork(BookReservationSystemDbContext context): base(context)
    {
    }

    public IRepository<Author> AuthorRepository => _authorRepository ??= new GenericRepository<Author>(Context);
    public IRepository<Book> BookRepository => _bookRepository ??= new GenericRepository<Book>(Context);
}