using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;

namespace BookReservationSystemInfrastructure.UnitOfWork;

public interface IPublisherUOW : IDisposable
{
    IRepository<Book> BookRepository { get; }
    IRepository<Publisher> PublisherRepository { get; }
    public Task Commit();
}