using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IAuthorUOW : IDisposable
{
    IRepository<Author> AuthorRepository { get; }
    IRepository<Book> BookRepository { get; }
    public Task Commit();
}