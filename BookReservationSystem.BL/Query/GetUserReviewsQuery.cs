using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.BL.Query
{
    public class GetUserReviewsQuery
    {
        private readonly IMapper _mapper;
        private IQuery<Review> _query;

        public GetUserReviewsQuery(IMapper mapper, IQuery<Review> query)
        {
            _mapper = mapper;
            _query = query;
        }

        public async Task<IEnumerable<ReviewDto>> Execute(UserDto userDto)
        {
            _query =  _query.Where(review => review.UserId == userDto.Id);
            var queryResult = await _query.Execute();
            return _mapper.Map<IEnumerable<ReviewDto>>(queryResult);
        }
    }
}
