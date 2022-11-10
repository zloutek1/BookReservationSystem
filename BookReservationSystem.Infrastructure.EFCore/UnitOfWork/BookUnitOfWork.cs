using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.Infrastructure.EFCore.UnitOfWork;

public class BookUnitOfWork : GenericUnitOfWork, IBookUnitOfWork
{
    private IRepository<Author>? _authorRepository;
    private IRepository<Book>? _bookRepository;
    private IRepository<Genre>? _genreRepository;
    private IRepository<Publisher>? _publisherRepository;
    private IRepository<Review>? _reviewRepository;
    private IRepository<BookQuantity>? _bookQuantityRepository;

    public BookUnitOfWork(BookReservationSystemDbContext context): base(context)
    {
    }

    public IRepository<Author> AuthorRepository => _authorRepository ??= new GenericRepository<Author>(Context);
    public IRepository<Book> BookRepository => _bookRepository ??= new GenericRepository<Book>(Context);
    public IRepository<Genre> GenreRepository => _genreRepository ??= new GenericRepository<Genre>(Context);
    public IRepository<Publisher> PublisherRepository => _publisherRepository ??= new GenericRepository<Publisher>(Context);
    public IRepository<Review> ReviewRepository => _reviewRepository ??= new GenericRepository<Review>(Context);
    public IRepository<BookQuantity> BookQuantityRepository => _bookQuantityRepository ??= new GenericRepository<BookQuantity>(Context);
}