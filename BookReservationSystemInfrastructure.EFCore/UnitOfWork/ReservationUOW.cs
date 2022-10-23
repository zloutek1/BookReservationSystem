using BookReservationSystemDAL.Data;
using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.EFCore.Repository;
using BookReservationSystemInfrastructure.Repository;
using BookReservationSystemInfrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemInfrastructure.EFCore.UnitOfWork
{
    public class ReservationUOW : IReservationUOW
    {
        private readonly BookReservationSystemDbContext _context;
        private IRepository<Book>? _bookRepository;
        private IRepository<Library>? _libraryRepository;
        private IRepository<Reservation>? _reservationRepository;
        private IRepository<User>? _userRepository;
        private IRepository<BookQuantity>? _bookQuantityRepository;

        public ReservationUOW(BookReservationSystemDbContext context)
        {
            _context = context;
        }

        public IRepository<Book> BookRepository => _bookRepository ??= new GenericRepository<Book>(_context);
        public IRepository<Library> LibraryRepository => _libraryRepository ??= new GenericRepository<Library>(_context);
        public IRepository<Reservation> ReservationRepository => _reservationRepository ??= new GenericRepository<Reservation>(_context);
        public IRepository<User> UserRepository => _userRepository ??= new GenericRepository<User>(_context);
        public IRepository<BookQuantity> BookQuantityRepository => _bookQuantityRepository ??= new GenericRepository<BookQuantity>(_context);

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
