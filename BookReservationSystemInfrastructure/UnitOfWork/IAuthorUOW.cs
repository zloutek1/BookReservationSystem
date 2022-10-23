using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.Repository;

namespace BookReservationSystemInfrastructure.UnitOfWork;

public interface IAuthorUOW : IDisposable
{
    IRepository<Author> AuthorRepository { get; }
    IRepository<Book> BookRepository { get; }
    public Task Commit();
}