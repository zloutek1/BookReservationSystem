using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;

namespace BookReservationSystem.BL.Query;

public class GetBookByReviewQuery
{
    private readonly IMapper _mapper;
    private IQuery<Book> _query;

    public GetBookByReviewQuery(IMapper mapper, IQuery<Book> query)
    {
        _mapper = mapper;
        _query = query;
    }

    public async Task<BookDto?> Execute(Guid reviewId)
    {
        _query = _query.Where(book => book.Reviews.Select(p => p.Id).Contains(reviewId));
        var queryResult = await _query.Execute();

        return _mapper.Map<IEnumerable<BookDto>>(queryResult).FirstOrDefault();
    }
}