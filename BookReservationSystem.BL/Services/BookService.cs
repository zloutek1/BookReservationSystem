using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.BL.Services;

public class BookService: ICrudService<BookDto>
{
    private readonly IMapper _mapper;
    private readonly Func<IUnitOfWork> _unitOfWorkFactory;
    private readonly IRepository<Book> _bookRepository;

    public BookService(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, IRepository<Book> bookRepository)
    {
        _mapper = mapper;
        _unitOfWorkFactory = unitOfWorkFactory;
        _bookRepository = bookRepository;
    }
    
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
        uow.Commit();
    }

    public void Update(BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        using var uow = _unitOfWorkFactory();
        _bookRepository.Update(book);
        uow.Commit();
    }

    public void Delete(Guid id)
    {
        using var uow = _unitOfWorkFactory();
        _bookRepository.Delete(id);
        uow.Commit();
    }
}