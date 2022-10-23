using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemInfrastructure.UnitOfWork
{
    public interface IGenreUOW : IDisposable
    { 
        IRepository<Book> BookRepository { get; }
        IRepository<Genre> GenreRepository { get; }
        public Task Commit();
    }
}
