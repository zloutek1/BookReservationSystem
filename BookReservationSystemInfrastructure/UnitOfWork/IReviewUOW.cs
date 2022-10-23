using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;

namespace BookReservationSystemInfrastructure.UnitOfWork;

public interface IReviewUOW : IDisposable
{
    IRepository<Book> BookRepository { get; }
    IRepository<Review> ReviewRepository { get; }
    IRepository<User> UserRepository { get; }
    public Task Commit();
}