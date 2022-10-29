﻿using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.Infrastructure.EFCore.UnitOfWork;

public class GenreUOW : GenericUOW, IGenreUOW
{
    private IRepository<Book>? _bookRepository;
    private IRepository<Genre>? _genreRepository;

    public GenreUOW(BookReservationSystemDbContext context) : base(context)
    {
    }

    public IRepository<Book> BookRepository => _bookRepository ??= new GenericRepository<Book>(Context);
    public IRepository<Genre> GenreRepository => _genreRepository ??= new GenericRepository<Genre>(Context);

}