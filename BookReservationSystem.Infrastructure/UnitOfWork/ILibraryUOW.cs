using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface ILibraryUOW : IDisposable
{
    IRepository<Address> AddressRepository { get; }
    IRepository<Book> BookRepository { get; }
    IRepository<Library> LibraryRepository { get; }
    IRepository<Reservation> ReservationRepository { get; }
    IRepository<BookQuantity> BookQuantityRepository { get; }
    public Task Commit();
}