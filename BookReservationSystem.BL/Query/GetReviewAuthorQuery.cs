using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;

namespace BookReservationSystem.BL.Query;

public class GetReviewAuthorQuery
{
    private readonly IMapper _mapper;
    private readonly IQuery<Review> _query;

    public GetReviewAuthorQuery(IMapper mapper, IQuery<Review> query)
    {
        _mapper = mapper;
        _query = query;
    }

    public BookDto Execute(ReviewDto reviewDto)
    {
        _query.Where<Guid>(bookId => bookId == reviewDto.Book.Id, "Id");
        return _mapper.Map<BookDto>(_query.Execute());
    }
}