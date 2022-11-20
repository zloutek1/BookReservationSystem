using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.BL.Services;

public class BookService: ICrudService<BookDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Book> _bookRepository;

    public BookService(IMapper mapper, IUnitOfWork unitOfWork, IRepository<Book> bookRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
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
        _bookRepository.Insert(book);
    }

    public void Update(BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        _bookRepository.Update(book);
    }

    public void Delete(Guid id)
    {
        _bookRepository.Delete(id);
    }
}