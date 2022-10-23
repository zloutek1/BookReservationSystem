using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;

namespace BookReservationSystemInfrastructure.UnitOfWork;

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