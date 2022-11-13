using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IAuthorUnitOfWork : IUnitOfWork
{
    IRepository<Author> AuthorRepository { get; }
    IRepository<Book> BookRepository { get; }
}