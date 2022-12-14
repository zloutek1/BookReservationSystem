﻿using AutoMapper;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.BL.Query;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.BL.Services;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly Func<IUnitOfWork> _unitOfWorkFactory;
    private readonly IRepository<Book> _bookRepository;
    private readonly IQuery<Book> _bookQuery;

    public BookService(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, IRepository<Book> bookRepository, IQuery<Book> bookQuery)
    {
        _mapper = mapper;
        _unitOfWorkFactory = unitOfWorkFactory;
        _bookRepository = bookRepository;
        _bookQuery = bookQuery;
    }

    #region crud
    public IEnumerable<BookDto> FindAll()
    {
        var foundBooks = _bookRepository.FindAll();
        return _mapper.Map<IEnumerable<BookDto>>(foundBooks);
    }

    public BookDto? FindById(Guid id)
    {
        var foundBook = _bookRepository.FindById(id);
        return _mapper.Map<BookDto?>(foundBook);
    }

    public void Insert(BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        using var uow = _unitOfWorkFactory();
        _bookRepository.Insert(book);
        //TODO: delete after uow is fixed x.x
        _bookRepository.Commit();
        uow.Commit();
    }

    public void Update(BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        using var uow = _unitOfWorkFactory();
        _bookRepository.Update(book);
        uow.Commit();
    }

    //TODO: delete all reviews and reservations for this book
    public void Delete(Guid id)
    {
        using var uow = _unitOfWorkFactory();
        _bookRepository.Delete(id);
        //TODO: delete after uow is fixed x.x
        _bookRepository.Commit();
        uow.Commit();
    }
    #endregion

    public IEnumerable<BookDto> FilterBooks(BookFilterDto filter)
    {
        var bookQuery = new FilterBookQuery(_mapper, _bookQuery);
        return bookQuery.Execute(filter);
    }
}