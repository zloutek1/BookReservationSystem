﻿using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IReservationUnitOfWork : IUnitOfWork
{
    IRepository<Book> BookRepository { get; }
    IRepository<Library> LibraryRepository { get; }
    IRepository<Reservation> ReservationRepository { get; }
    IRepository<User> UserRepository { get; }
    IRepository<BookQuantity> BookQuantityRepository { get; }

}