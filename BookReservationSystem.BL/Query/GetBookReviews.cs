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
    public class GetBookReviews
    {
        private readonly IMapper _mapper;
        private readonly IQuery<Review> _query;

        public GetBookReviews(IMapper mapper, IQuery<Review> query)
        {
            _mapper = mapper;
            _query = query;
        }

        public IEnumerable<ReviewDto> Execute(BookDto bookDto)
        {
            _query.Where<Guid>(id => id == bookDto.Id, "Id");
            return _mapper.Map<IEnumerable<ReviewDto>>(_query.Execute());
        }
    }
}
