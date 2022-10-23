using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemInfrastructure.UnitOfWork
{
    public interface IReservationUOW : IDisposable
    {
        IRepository<Book> BookRepository { get; }
        IRepository<Library> LibraryRepository { get; }
        IRepository<Reservation> ReservationRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<BookQuantity> BookQuantityRepository { get; }
        public Task Commit();

    }
}
