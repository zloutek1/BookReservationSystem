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
    public class PublisherUOW : IUnitOfWork
    {
        private readonly BookReservationSystemDbContext _context;
        private IRepository<Book>? _bookRepository;
        private IRepository<Publisher>? _publisherRepository;

        public PublisherUOW()
        {
            _context = new BookReservationSystemDbContext();
        }

        public PublisherUOW(BookReservationSystemDbContext context)
        {
            _context = context;
        }

        public IRepository<Book> BookRepository => _bookRepository ??= new GenericRepository<Book>(_context);
        public IRepository<Publisher> PublisherRepository => _publisherRepository ??= new GenericRepository<Publisher>(_context);

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
