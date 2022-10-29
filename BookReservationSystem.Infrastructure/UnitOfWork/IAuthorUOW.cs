using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IAuthorUOW : IUnitOfWork
{
    IRepository<Author> AuthorRepository { get; }
    IRepository<Book> BookRepository { get; }
}