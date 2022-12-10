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
    public class GetReservationHistoryQuery
    {
        private readonly IMapper _mapper;
        private readonly IQuery<Reservation> _query;

        public GetReservationHistoryQuery(IMapper mapper, IQuery<Reservation> query)
        {
            _mapper = mapper;
            _query = query;
        }

        public IEnumerable<ReservationDto> Execute(ReservationUserFilterDto reservationUserFilterDto)
        {
            _query.Where<string>(email => email == reservationUserFilterDto.Email, "Email")
                .OrderBy<string>("ReservationDate", true);

            if (reservationUserFilterDto.RequestedPageNumber.HasValue)
            {
                _query.Page(reservationUserFilterDto.RequestedPageNumber.Value, reservationUserFilterDto.PageSize);
            }

            return _mapper.Map<IEnumerable<ReservationDto>>(_query.Execute());
        }
    }
}
