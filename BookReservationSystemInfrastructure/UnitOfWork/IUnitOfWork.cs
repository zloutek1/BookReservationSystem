using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReservationSystemInfrastructure.Repository;
using BookReservationSystemDAL.Models;

namespace BookReservationSystemInfrastructure.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<Address> AddressRepository { get; }
    IRepository<Author> AuthorRepository { get; }
    IRepository<BaseEntity> BaseEntityRepository { get; }
    IRepository<Book> BookRepository { get; }
    IRepository<Genre> GenreRepository { get; }
    IRepository<Library> LibraryRepository { get; }
    IRepository<Publisher> PublisherRepository { get; }
    IRepository<Reservation> ReservationRepository { get; }
    IRepository<Review> ReviewRepository { get; }
    IRepository<Role> RoleRepository { get; }
    IRepository<User> UserRepository { get; }
    public Task Commit();
}