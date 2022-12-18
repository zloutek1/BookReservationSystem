using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.BL.Query;

public class GetBookReviewsQuery
{
    private readonly IMapper _mapper;
    private IQuery<Review> _query;

    public GetBookReviewsQuery(IMapper mapper, IQuery<Review> query)
    {
        _mapper = mapper;
        _query = query;
    }

    public async Task<IEnumerable<ReviewDto>> Execute(BookDto bookDto)
    {
        _query = _query.Where(review => review.BookId == bookDto.Id);
        var queryResult = await _query.Execute();
        return _mapper.Map<IEnumerable<ReviewDto>>(queryResult);
    }
}