using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReservationSystemInfrastructure.Repository;
using BookReservationSystemDAL.Models;

namespace BookReservationSystemInfrastructure.UnitOfWork
{
    internal interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Address> AddressRepository { get; }
        IGenericRepository<Author> AuthorRepository { get; }
        IGenericRepository<AuthorRelation> AuthorRelationRepository { get; }
        IGenericRepository<BaseEntity> BaseEntityRepository { get; }
        IGenericRepository<Book> BookRepository { get; }
        IGenericRepository<BookQuantityRelation> BookQuantityRelationRepository { get; }
        IGenericRepository<Genre> GenreRepository { get; }
        IGenericRepository<Library> LibraryRepository { get; }
        IGenericRepository<Publisher> PublisherRepository { get; }
        IGenericRepository<Reservation> ReservationRepository { get; }
        IGenericRepository<Review> ReviewRepository { get; }
        IGenericRepository<Role> RoleRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        public Task SaveCommit();
    }
}
