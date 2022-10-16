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
using System.Xml.Linq;

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

        public IGenericRepository<Address> AddressRepository
        {
            get
            {
                if (addressRepository == null)
                {
                    addressRepository = new GenericRepository<Address>(_context);
                }
                return addressRepository;
            }
        }
        public IGenericRepository<Author> AuthorRepository
        {
            get
            {
                if (authorRepository == null)
                {
                    authorRepository = new GenericRepository<Author>(_context);
                }
                return authorRepository;
            }
        }
        public IGenericRepository<AuthorRelation> AuthorRelationRepository
        {
            get
            {
                if (authorRelationRepository == null)
                {
                    authorRelationRepository = new GenericRepository<AuthorRelation>(_context);
                }
                return authorRelationRepository;
            }
        }
        public IGenericRepository<BaseEntity> BaseEntityRepository
        {
            get
            {
                if (baseEntityRepository == null)
                {
                    baseEntityRepository = new GenericRepository<BaseEntity>(_context);
                }
                return baseEntityRepository;
            }
        }
        public IGenericRepository<Book> BookRepository
        {
            get
            {
                if (bookRepository == null)
                {
                    bookRepository = new GenericRepository<Book>(_context);
                }
                return bookRepository;
            }
        }
        public IGenericRepository<BookQuantityRelation> BookQuantityRelationRepository
        {
            get
            {
                if (bookQuantityRelationRepository == null)
                {
                    bookQuantityRelationRepository = new GenericRepository<BookQuantityRelation>(_context);
                }
                return bookQuantityRelationRepository;
            }
        }
        public IGenericRepository<Genre> GenreRepository
        {
            get
            {
                if (genreRepository == null)
                {
                    genreRepository = new GenericRepository<Genre>(_context);
                }
                return genreRepository;
            }
        }
        public IGenericRepository<Library> LibraryRepository
        {
            get
            {
                if (libraryRepository == null)
                {
                    libraryRepository = new GenericRepository<Library>(_context);
                }
                return libraryRepository;
            }
        }
        public IGenericRepository<Publisher> PublisherRepository
        {
            get
            {
                if (publisherRepository == null)
                {
                    publisherRepository = new GenericRepository<Publisher>(_context);
                }
                return publisherRepository;
            }
        }
        public IGenericRepository<Reservation> ReservationRepository
        {
            get
            {
                if (reservationRepository == null)
                {
                    reservationRepository = new GenericRepository<Reservation>(_context);
                }
                return reservationRepository;
            }
        }
        public IGenericRepository<Review> ReviewRepository
        {
            get
            {
                if (reviewRepository == null)
                {
                    reviewRepository = new GenericRepository<Review>(_context);
                }
                return reviewRepository;
            }
        }
        public IGenericRepository<Role> RoleRepository
        {
            get
            {
                if (roleRepository == null)
                {
                    roleRepository = new GenericRepository<Role>(_context);
                }
                return roleRepository;
            }
        }
        public IGenericRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new GenericRepository<User>(_context);
                }
                return userRepository;
            }
        }

        #endregion

        public async Task SaveCommit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
