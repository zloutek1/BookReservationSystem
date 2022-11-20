using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;

namespace BookReservationSystem.BL.Query;

public class BookQuery
{
    private readonly IMapper _mapper;
    private readonly IQuery<Book> _query;

    public BookQuery(IMapper mapper, IQuery<Book> query)
    {
        _mapper = mapper;
        _query = query;
    }

    public IEnumerable<BookDto> Execute(BookFilterDto bookFilterDto)
    {
        _query.Where<string>(name => name == bookFilterDto.Name, "Name");

        if (!string.IsNullOrWhiteSpace(bookFilterDto.SortCriteria))
        {
            _query.OrderBy<string>(bookFilterDto.SortCriteria, bookFilterDto.SortAscending);
        }

        if (bookFilterDto.RequestedPageNumber.HasValue)
        {
            _query.Page(bookFilterDto.RequestedPageNumber.Value, bookFilterDto.PageSize);
        }

        return _mapper.Map<IEnumerable<BookDto>>(_query.Execute());
    }
}