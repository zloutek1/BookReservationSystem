using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookReservationSystem.BL.Query
{
    public class FilterReviewsQuery
    {
        private readonly IMapper _mapper;
        private readonly IQuery<Review> _query;

        public FilterReviewsQuery(IMapper mapper, IQuery<Review> query)
        {
            _mapper = mapper;
            _query = query;
        }

        public IEnumerable<ReviewDto> Execute(ReviewUserFilterDto reviewUserFilterDto)
        {
            _query.Where<string>(email => email == reviewUserFilterDto.Email, "Email");

            if (!string.IsNullOrWhiteSpace(reviewUserFilterDto.SortCriteria))
            {
                _query.OrderBy<string>(reviewUserFilterDto.SortCriteria, reviewUserFilterDto.SortAscending);
            }

            if (reviewUserFilterDto.RequestedPageNumber.HasValue)
            {
                _query.Page(reviewUserFilterDto.RequestedPageNumber.Value, reviewUserFilterDto.PageSize);
            }

            return _mapper.Map<IEnumerable<ReviewDto>>(_query.Execute());
        }
    }
}
