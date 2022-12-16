using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.UnitOfWork;
using BookReservationSystem.BL.Query;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.BL.IServices;

namespace BookReservationSystem.BL.Services;

public class UserService: IUserService
{
    private readonly IMapper _mapper;
    private readonly Func<IUnitOfWork> _unitOfWorkFactory;
    private readonly IRepository<User> _userRepository;
    private readonly IQuery<User> _userQuery;

    public UserService(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, IRepository<User> userRepository, IQuery<User> userQuery)
    {
        _mapper = mapper;
        _unitOfWorkFactory = unitOfWorkFactory;
        _userRepository = userRepository;
        _userQuery = userQuery;
    }

    //make crud class for user profile dto, revert back to crud on userdto
    #region crud
    public async Task<IEnumerable<UserDto>> FindAll()
    {
        var foundUsers = _userRepository.FindAll();
        return _mapper.Map<IEnumerable<UserProfileDto>>(foundUsers);
    }

    public async Task<UserDto?> FindById(Guid id)
    {
        var foundUser = await _userRepository.FindById(id);
        return _mapper.Map<UserDto?>(foundUser);
    }

    public async Task Update(UserEditDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        await using var uow = _unitOfWorkFactory();
        await _userRepository.Update(user);
        await uow.Commit();
    }

    public async Task Delete(Guid id)
    {
        await using var uow = _unitOfWorkFactory();
        await _userRepository.Delete(id);
        await uow.Commit();
    }
    #endregion

    public async Task<UserDto?> FindByUsername(string username)
    {
        var userQuery = new FilterUserQuery(_mapper, _userQuery);
        return userQuery.Execute(new UserFilterDto { UserName = username, SortAscending = true });
    }

    public void RegisterUser(UserCreateDto userCreateDto)
    {
        var passwordSalt = _securityHelper.GenerateSalt();
        var passwordHash = _securityHelper.HashPassword(userCreateDto.Password, passwordSalt);

        var user = new User
        {
            Email = userCreateDto.Email,
            FirstName = userCreateDto.FirstName,
            LastName = userCreateDto.LastName,
            PasswordSalt = passwordSalt,
            PasswordHash = passwordHash
        };

        using var uow = _unitOfWorkFactory();
        _userRepository.Insert(user);
        uow.Commit();
    }
}