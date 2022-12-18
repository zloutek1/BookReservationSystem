using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;

namespace BookReservationSystem.BL.Query;

public class FilterBookNotInLibraryQuery
{
    private readonly IMapper _mapper;
    private IQuery<Book> _query;

    public FilterBookNotInLibraryQuery(IMapper mapper, IQuery<Book> query)
    {
        _mapper = mapper;
        _query = query;
    }

    public async Task<IEnumerable<BookDto>> Execute(Guid libraryId)
    {
        _query = _query.Where(b => b.BookQuantities.All(q => q.LibraryId != libraryId));
        
        var queryResult = await _query.Execute();
        return _mapper.Map<IEnumerable<BookDto>>(queryResult);
    }
}