using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IReviewUOW : IUnitOfWork
{
    IRepository<Book> BookRepository { get; }
    IRepository<Review> ReviewRepository { get; }
    IRepository<User> UserRepository { get; }
}