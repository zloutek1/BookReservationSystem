using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IPublisherUOW : IUnitOfWork
{
    IRepository<Book> BookRepository { get; }
    IRepository<Publisher> PublisherRepository { get; }
}