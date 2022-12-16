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

    public async Task<UserDto?> Execute(UserFilterDto userFilterDto)
    {
        _query.Where(user => user.UserName == userFilterDto.UserName);
        
        // TODO: add sorting?
        
        if (userFilterDto.RequestedPageNumber.HasValue)
        {
            _query.Page(userFilterDto.RequestedPageNumber.Value, userFilterDto.PageSize);
        }

        var queryResult = await _query.Execute();
        return _mapper.Map<UserDto?>(queryResult.FirstOrDefault());
    }
}