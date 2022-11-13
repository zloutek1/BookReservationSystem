using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.Infrastructure.EFCore.UnitOfWork;

public class PublisherUnitOfWork : GenericUnitOfWork, IPublisherUnitOfWork
{
    private IRepository<Book>? _bookRepository;
    private IRepository<Publisher>? _publisherRepository;

    public PublisherUnitOfWork(BookReservationSystemDbContext context): base(context)
    {
    }

    public IRepository<Book> BookRepository => _bookRepository ??= new GenericRepository<Book>(Context);
    public IRepository<Publisher> PublisherRepository => _publisherRepository ??= new GenericRepository<Publisher>(Context);
}