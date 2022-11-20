using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.BL.Services;

public class BookService: ICrudService<BookDto>
{
    private readonly IMapper _mapper;
    private readonly IBookUnitOfWork _bookUnitOfWork;
    
    public BookService(IMapper mapper, IBookUnitOfWork bookUnitOfWork)
    {
        _mapper = mapper;
        _bookUnitOfWork = bookUnitOfWork;
    }
    
    public IEnumerable<BookDto> FindAll()
    {
        var foundBooks = _bookUnitOfWork.BookRepository.FindAll();
        return _mapper.Map<IEnumerable<BookDto>>(foundBooks);
    }

    public BookDto? FindById(Guid id)
    {
        var foundBook = _bookUnitOfWork.BookRepository.FindById(id);
        return _mapper.Map<BookDto?>(foundBook);
    }

    public IEnumerable<BookDto> GetBooksWithName(string name)
    {
        bookQueryObject = new BookQueryObject(_mapper, _bookUnitOfWork);
        return bookQueryObject.Execute(new BookFilterDto() { Name = name, SortAscending = true }).Items;
    }

    public void Insert(BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        _bookUnitOfWork.BookRepository.Insert(book);
    }

    public void Update(BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        _bookUnitOfWork.BookRepository.Update(book);
    }

    public void Delete(Guid id)
    {
        _bookUnitOfWork.BookRepository.Delete(id);
    }
}