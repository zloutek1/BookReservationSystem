using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.UnitOfWork;
using BookReservationSystem.BL.Query;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.BL.IServices;
using Microsoft.AspNetCore.Identity;
using BookReservationSystem.BL.Exceptions;

namespace BookReservationSystem.BL.Services;

public class UserService: CrudService<User, UserDto>, IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(IQuery<User> query, IRepository<User> repository, IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, UserManager<User> userManager) : base(query, repository, mapper, unitOfWorkFactory)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<UserDto>> FilterUsers(UserFilterDto filter)
    {
        var userQuery = new FilterUserQuery(Mapper, Query);
        return await userQuery.Execute(filter);
    }

    public async new Task Update(UserDto updateDto)
    {
        var userTemp = Mapper.Map<User>(updateDto);
        userTemp.SecurityStamp = Guid.NewGuid().ToString();
        var user = await _userManager.FindByNameAsync(updateDto.UserName);
        if (user != null)
        {
            user.FirstName = updateDto.FirstName;
            user.LastName = updateDto.LastName;
            await _userManager.UpdateAsync(user);
        }
    }
}