using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.UnitOfWork;
using BookReservationSystem.BL.Query;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.BL.IServices;
using Castle.Core.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Identity;
using System.Security;
using Microsoft.EntityFrameworkCore;

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
        var user = Mapper.Map<User>(updateDto);
        user.SecurityStamp = Guid.NewGuid().ToString();
        await _userManager.UpdateAsync(user);
        await using var uow = UnitOfWorkFactory();
        await Repository.Update(user);
        await uow.Commit();
    }
}