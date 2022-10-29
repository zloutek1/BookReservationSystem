using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.Infrastructure.EFCore.UnitOfWork;

public class BookUOW : IBookUOW
{
    private readonly BookReservationSystemDbContext _context;
    private IRepository<Author>? _authorRepository;
    private IRepository<Book>? _bookRepository;
    private IRepository<Genre>? _genreRepository;
    private IRepository<Publisher>? _publisherRepository;
    private IRepository<Review>? _reviewRepository;
    private IRepository<BookQuantity>? _bookQuantityRepository;

    public BookUOW(BookReservationSystemDbContext context)
    {
        _context = context;
    }

    public IRepository<Author> AuthorRepository => _authorRepository ??= new GenericRepository<Author>(_context);
    public IRepository<Book> BookRepository => _bookRepository ??= new GenericRepository<Book>(_context);
    public IRepository<Genre> GenreRepository => _genreRepository ??= new GenericRepository<Genre>(_context);
    public IRepository<Publisher> PublisherRepository => _publisherRepository ??= new GenericRepository<Publisher>(_context);
    public IRepository<Review> ReviewRepository => _reviewRepository ??= new GenericRepository<Review>(_context);
    public IRepository<BookQuantity> BookQuantityRepository => _bookQuantityRepository ??= new GenericRepository<BookQuantity>(_context);

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}