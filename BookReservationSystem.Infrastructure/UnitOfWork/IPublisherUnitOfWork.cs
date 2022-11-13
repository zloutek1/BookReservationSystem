using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IPublisherUnitOfWork : IUnitOfWork
{
    IRepository<Book> BookRepository { get; }
    IRepository<Publisher> PublisherRepository { get; }
}