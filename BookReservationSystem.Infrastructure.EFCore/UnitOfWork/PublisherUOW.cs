using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.Infrastructure.EFCore.UnitOfWork;

public class PublisherUOW : IPublisherUOW
{
    private readonly BookReservationSystemDbContext _context;
    private IRepository<Book>? _bookRepository;
    private IRepository<Publisher>? _publisherRepository;

    public PublisherUOW(BookReservationSystemDbContext context)
    {
        _context = context;
    }

    public IRepository<Book> BookRepository => _bookRepository ??= new GenericRepository<Book>(_context);
    public IRepository<Publisher> PublisherRepository => _publisherRepository ??= new GenericRepository<Publisher>(_context);

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}