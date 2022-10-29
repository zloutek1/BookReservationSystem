using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IGenreUOW : IUnitOfWork
{ 
    IRepository<Book> BookRepository { get; }
    IRepository<Genre> GenreRepository { get; }
}