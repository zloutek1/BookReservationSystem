﻿using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IBookUOW : IUnitOfWork
{      
    IRepository<Author> AuthorRepository { get; }
    IRepository<Book> BookRepository { get; }
    IRepository<Genre> GenreRepository { get; }
    IRepository<Publisher> PublisherRepository { get; }
    IRepository<Review> ReviewRepository { get; }
    IRepository<BookQuantity> BookQuantityRepository { get; }
}