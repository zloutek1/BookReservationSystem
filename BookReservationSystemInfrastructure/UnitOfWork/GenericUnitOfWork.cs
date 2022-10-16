using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReservationSystemInfrastructure.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using BookReservationSystemDAL.Data;
using BookReservationSystemDAL.Models;

namespace BookReservationSystemInfrastructure.UnitOfWork
{
    public class UnitOfWork : IDisposable 
    {
        private BookReservationSystemDBContext _context = null;
        public UnitOfWork()
        {
            _context = new BookReservationSystemDBContext();
        }

        public UnitOfWork(BookReservationSystemDBContext _context)
        {
            this._context = _context;
        }

        #region repositories

        private IGenericRepository<Address> addressRepository;
        private IGenericRepository<Author> authorRepository;
        private IGenericRepository<AuthorRelation> authorRelationRepository;
        private IGenericRepository<BaseEntity> baseEntityRepository;
        private IGenericRepository<Book> bookRepository;
        private IGenericRepository<BookQuantityRelation> bookQuantityRelationRepository;
        private IGenericRepository<Genre> genreRepository;
        private IGenericRepository<Library> libraryRepository;
        private IGenericRepository<Publisher> publisherRepository;
        private IGenericRepository<Reservation> reservationRepository;
        private IGenericRepository<Review> reviewRepository;
        private IGenericRepository<Role> roleRepository;
        private IGenericRepository<User> userRepository;

        public IGenericRepository<Address> AddressRepository => addressRepository ?? new GenericRepository<Address>(_context);
        public IGenericRepository<Author> AuthorRepository => authorRepository ?? new GenericRepository<Author>(_context);
        public IGenericRepository<AuthorRelation> AuthorRelationRepository => authorRelationRepository ?? new GenericRepository<AuthorRelation>(_context);
        public IGenericRepository<BaseEntity> BaseEntityRepository => baseEntityRepository ?? new GenericRepository<BaseEntity>(_context);
        public IGenericRepository<Book> BookRepository => bookRepository ?? new GenericRepository<Book>(_context);
        public IGenericRepository<BookQuantityRelation> BookQuantityRelationRepository => bookQuantityRelationRepository ?? new GenericRepository<BookQuantityRelation>(_context);
        public IGenericRepository<Genre> GenreRepository => genreRepository ?? new GenericRepository<Genre>(_context);
        public IGenericRepository<Library> LibraryRepository => libraryRepository ?? new GenericRepository<Library>(_context);
        public IGenericRepository<Publisher> PublisherRepository => publisherRepository ?? new GenericRepository<Publisher>(_context);
        public IGenericRepository<Reservation> ReservationRepository => reservationRepository ?? new GenericRepository<Reservation>(_context);
        public IGenericRepository<Review> ReviewRepository => reviewRepository ?? new GenericRepository<Review>(_context);
        public IGenericRepository<Role> RoleRepository => roleRepository ?? new GenericRepository<Role>(_context);
        public IGenericRepository<User> UserRepository => userRepository ?? new GenericRepository<User>(_context);

        #endregion

        public async Task<bool> Complete() => await _context.SaveChangesAsync() > 0;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
