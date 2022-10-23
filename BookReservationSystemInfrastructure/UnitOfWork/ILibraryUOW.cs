using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;

namespace BookReservationSystemInfrastructure.UnitOfWork;

public interface ILibraryUOW : IDisposable
{
    IRepository<Address> AddressRepository { get; }
    IRepository<Book> BookRepository { get; }
    IRepository<Library> LibraryRepository { get; }
    IRepository<Reservation> ReservationRepository { get; }
    IRepository<BookQuantity> BookQuantityRepository { get; }
    public Task Commit();
}