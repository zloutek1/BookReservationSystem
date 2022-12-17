using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;

namespace BookReservationSystem.BL.Query;

public class FilterBookQuery
{
    private readonly IMapper _mapper;
    private IQuery<Book> _query;

    public FilterBookQuery(IMapper mapper, IQuery<Book> query)
    {
        _mapper = mapper;
        _query = query;
    }

    public async Task<IEnumerable<BookDto>> Execute(BookFilterDto bookFilterDto)
    {
        if (bookFilterDto.Name != null)
        {
            _query = _query.Where(book => book.Name.ToLower().Contains(bookFilterDto.Name!.ToLower()));
        }

        if (bookFilterDto.Isbn != null)
        {
            _query = _query.Where(book => book.Isbn.Equals(bookFilterDto.Isbn));
        }

        if (bookFilterDto.Author != null)
        {
            _query = _query.Where(book => book.Authors.Select(a => a.Name).Contains(bookFilterDto.Author));
        }

        if (bookFilterDto.Publisher != null)
        {
            _query = _query.Where(book => book.Publishers.Select(p => p.Name).Contains(bookFilterDto.Publisher));
        }

        if (bookFilterDto.Genre != null)
        {
            _query = _query.Where(book => book.Genres.Select(g => g.Name).Contains(bookFilterDto.Genre));
        }

        if (bookFilterDto.OnlyAvailable)
        {
            _query.Where(book => book.BookQuantities.Count > 0);
        }

        if (bookFilterDto.SortByRating)
        {
            _query.OrderBy(book => book.Rating, bookFilterDto.SortAscending);
        }

        if (bookFilterDto.RequestedPageNumber.HasValue)
        {
            _query.Page(bookFilterDto.RequestedPageNumber.Value, bookFilterDto.PageSize);
        }
        
        var queryResult = await _query.Execute();
        return _mapper.Map<IEnumerable<BookDto>>(queryResult);
    }
}