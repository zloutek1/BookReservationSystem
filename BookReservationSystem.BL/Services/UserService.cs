using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.UnitOfWork;
using BookReservationSystem.BL.Helpers;
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
    private readonly ISecurityHelper _securityHelper;
    private readonly IQuery<User> _userQuery;

    public UserService(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, IRepository<User> userRepository, ISecurityHelper securityHelper, IQuery<User> userQuery)
    {
        _mapper = mapper;
        _unitOfWorkFactory = unitOfWorkFactory;
        _userRepository = userRepository;
        _securityHelper = securityHelper;
        _userQuery = userQuery;
    }

    //make crud class for user profile dto, revert back to crud on userdto
    #region crud
    public IEnumerable<UserProfileDto> FindAll()
    {
        var foundUsers = _userRepository.FindAll();
        return _mapper.Map<IEnumerable<UserProfileDto>>(foundUsers);
    }

    public UserProfileDto? FindById(Guid id)
    {
        var foundUser = _userRepository.FindById(id);
        return _mapper.Map<UserProfileDto?>(foundUser);
    }

    public void Insert(UserProfileDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        using var uow = _unitOfWorkFactory();
        _userRepository.Insert(user);
        uow.Commit();
    }

    public void Update(UserProfileDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        using var uow = _unitOfWorkFactory();
        _userRepository.Update(user);
        uow.Commit();
    }

    //delete all reservations and reviews for this user
    public void Delete(Guid id)
    {
        using var uow = _unitOfWorkFactory();
        _userRepository.Delete(id);
        uow.Commit();
    }
    #endregion

    public UserDto? FindByUsername(string username)
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