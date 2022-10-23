using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemInfrastructure.UnitOfWork
{
    public interface IBookUOW : IDisposable
    {      
        IRepository<Author> AuthorRepository { get; }
        IRepository<Book> BookRepository { get; }
        IRepository<Genre> GenreRepository { get; }
        IRepository<Publisher> PublisherRepository { get; }
        IRepository<Review> ReviewRepository { get; }
        IRepository<BookQuantity> BookQuantityRepository { get; }
        public Task Commit();
    }
}
