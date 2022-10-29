using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IReservationUOW : IDisposable
{
    IRepository<Book> BookRepository { get; }
    IRepository<Library> LibraryRepository { get; }
    IRepository<Reservation> ReservationRepository { get; }
    IRepository<User> UserRepository { get; }
    IRepository<BookQuantity> BookQuantityRepository { get; }
    public Task Commit();

}