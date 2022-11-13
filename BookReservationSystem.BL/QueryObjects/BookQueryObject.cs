using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;

namespace BookReservationSystem.BL.QueryObjects;

public class BookQueryObject
{
    private readonly IMapper _mapper;
    private readonly IQuery<Book> _query;

    public BookQueryObject(IMapper mapper, IQuery<Book> query)
    {
        _mapper = mapper;
        _query = query;
    }

    public QueryResultDto<Book> Execute(BookFilterDto bookFilterDto)
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

        return _mapper.Map<QueryResultDto<Book>>(_query.Execute());
    }
}