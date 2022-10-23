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
    public class ReviewUOW : IReviewUOW
    {
        private readonly BookReservationSystemDbContext _context;
        private IRepository<Book>? _bookRepository;
        private IRepository<Review>? _reviewRepository;
        private IRepository<User>? _userRepository;

        public ReviewUOW()
        {
            _context = new BookReservationSystemDbContext();
        }

        public ReviewUOW(BookReservationSystemDbContext context)
        {
            _context = context;
        }

        public IRepository<Book> BookRepository => _bookRepository ??= new GenericRepository<Book>(_context);
        public IRepository<Review> ReviewRepository => _reviewRepository ??= new GenericRepository<Review>(_context);
        public IRepository<User> UserRepository => _userRepository ??= new GenericRepository<User>(_context);

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
