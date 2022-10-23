using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;

namespace BookReservationSystemInfrastructure.UnitOfWork;

public interface IGenreUOW : IDisposable
{ 
    IRepository<Book> BookRepository { get; }
    IRepository<Genre> GenreRepository { get; }
    public Task Commit();
}