using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemInfrastructure.UnitOfWork
{
    public interface ILibraryUOW : IDisposable
    {
        IRepository<Address> AddressRepository { get; }
        IRepository<Book> BookRepository { get; }
        IRepository<Library> LibraryRepository { get; }
        IRepository<Reservation> ReservationRepository { get; }
        IRepository<BookQuantity> BookQuantityRepository { get; }
        public Task Commit();
    }
}
