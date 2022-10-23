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
    public class AuthorUOW : IAuthorUOW
    {
        private readonly BookReservationSystemDbContext _context;
        private IRepository<Author>? _authorRepository;
        private IRepository<Book>? _bookRepository;

        public AuthorUOW(BookReservationSystemDbContext context)
        {
            _context = context;
        }

        public IRepository<Author> AuthorRepository => _authorRepository ??= new GenericRepository<Author>(_context);
        public IRepository<Book> BookRepository => _bookRepository ??= new GenericRepository<Book>(_context);

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
