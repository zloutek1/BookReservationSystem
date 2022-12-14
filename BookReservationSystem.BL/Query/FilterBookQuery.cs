using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using System.Linq;

namespace BookReservationSystem.BL.Query;

public class FilterBookQuery
{
    private readonly IMapper _mapper;
    private readonly IQuery<Book> _query;

    public FilterBookQuery(IMapper mapper, IQuery<Book> query)
    {
        _mapper = mapper;
        _query = query;
    }

    public IEnumerable<BookDto> Execute(BookFilterDto bookFilterDto)
    {
        // TODO: repair query
        _query
            .Where<string>(name => name.ToLower().Contains(bookFilterDto.Name.ToLower()) || bookFilterDto.Name == "", "Name")
            .Where<long>(isbn => isbn.Equals(bookFilterDto.Isbn) || bookFilterDto.Isbn.Equals(0), "Isbn");
            //.Where<List<Author>>(author => author.Select(a => a.Name).Contains(bookFilterDto.Author) || bookFilterDto.Author == "", "Authors")
            //.Where<List<Publisher>>(publisher => publisher.Select(p => p.Name).Contains(bookFilterDto.Publisher) || bookFilterDto.Publisher == "", "Publishers")
            //.Where<List<Genre>>(genre => genre.Select(g => g.Name).Contains(bookFilterDto.Genre), "Genres");

        //if (!string.IsNullOrWhiteSpace(bookFilterDto.SortCriteria))
        //{
        //    _query.OrderBy<string>(bookFilterDto.SortCriteria, bookFilterDto.SortAscending);
        //}

        if (bookFilterDto.OnlyAvailable)
        {
            _query.Where<BookQuantity>(quantityObj => quantityObj.Count > 0, "Quantity");
        }

        if (bookFilterDto.SortByRating)
        {
            _query.OrderBy<string>("Average", bookFilterDto.SortAscending);
        }

        if (bookFilterDto.RequestedPageNumber.HasValue)
        {
            _query.Page(bookFilterDto.RequestedPageNumber.Value, bookFilterDto.PageSize);
        }

        return _mapper.Map<IEnumerable<BookDto>>(_query.Execute());
    }
}