using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;

namespace BookReservationSystem.BL.Query;

public class FilterUserQuery
{
    private readonly IMapper _mapper;
    private readonly IQuery<User> _query;

    public FilterUserQuery(IMapper mapper, IQuery<User> query)
    {
        _mapper = mapper;
        _query = query;
    }

    public IEnumerable<UserDto> Execute(UserFilterDto userFilterDto)
    {
        _query.Where<string>(email => email == userFilterDto.Email, "Email");

        if (!string.IsNullOrWhiteSpace(userFilterDto.SortCriteria))
        {
            _query.OrderBy<string>(userFilterDto.SortCriteria, userFilterDto.SortAscending);
        }

        if (userFilterDto.RequestedPageNumber.HasValue)
        {
            _query.Page(userFilterDto.RequestedPageNumber.Value, userFilterDto.PageSize);
        }

        return _mapper.Map<IEnumerable<UserDto>>(_query.Execute());
    }
}