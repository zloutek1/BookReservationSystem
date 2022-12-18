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

namespace BookReservationSystem.BL.Services;

public class UserService: CrudService<User, UserDto>, IUserService
{
    public UserService(IQuery<User> query, IRepository<User> repository, IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory) : base(query, repository, mapper, unitOfWorkFactory)
    {
    }

    public async Task<IEnumerable<UserDto>> FilterUsers(UserFilterDto filter)
    {
        var userQuery = new FilterUserQuery(Mapper, Query);
        return await userQuery.Execute(filter);
    }
}