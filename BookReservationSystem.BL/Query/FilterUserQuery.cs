using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;

namespace BookReservationSystem.BL.Query;

public class FilterUserQuery
{
    private readonly IMapper _mapper;
    private IQuery<User> _query;

    public FilterUserQuery(IMapper mapper, IQuery<User> query)
    {
        _mapper = mapper;
        _query = query;
    }

    public async Task<IEnumerable<UserDto>> Execute(UserFilterDto userFilterDto)
    {
        if (userFilterDto.Name != null)
        {
            _query = _query.Where(user => (user.FirstName.ToLower() + user.LastName.ToLower()).Contains(userFilterDto.Name!.ToLower()));
        }

        if (userFilterDto.UserName != null)
        {
            _query = _query.Where(user => user.UserName.ToLower().Contains(userFilterDto.UserName!.ToLower()));
        }

        if (userFilterDto.Email != null)
        {
            _query = _query.Where(user => user.Email.ToLower().Contains(userFilterDto.Email!.ToLower()));
        }

        if (userFilterDto.RequestedPageNumber.HasValue)
        {
            _query.Page(userFilterDto.RequestedPageNumber.Value, userFilterDto.PageSize);
        }

        var queryResult = await _query.Execute();
        return _mapper.Map<IEnumerable<UserDto>>(queryResult);
    }
}