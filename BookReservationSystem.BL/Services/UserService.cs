using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.UnitOfWork;
using BookReservationSystem.BL.Helpers;
using System.Security.Cryptography;
using BookReservationSystem.BL.Query;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;

namespace BookReservationSystem.BL.Services;

public class UserService: ICrudService<UserDto>
{
    private readonly IMapper _mapper;
    private readonly Func<IUnitOfWork> _unitOfWorkFactory;
    private readonly IRepository<User> _userRepository;
    private readonly SecurityHelper _securityHelper;
    private readonly IQuery<User> _userQuery;

    public UserService(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, IRepository<User> userRepository, SecurityHelper securityHelper, IQuery<User> userQuery)
    {
        _mapper = mapper;
        _unitOfWorkFactory = unitOfWorkFactory;
        _userRepository = userRepository;
        _securityHelper = securityHelper;
        _userQuery = userQuery;
    }
    
    public IEnumerable<UserDto> FindAll()
    {
        var foundUsers = _userRepository.FindAll();
        return _mapper.Map<IEnumerable<UserDto>>(foundUsers);
    }

    public UserDto? FindById(Guid id)
    {
        var foundUser = _userRepository.FindById(id);
        return _mapper.Map<UserDto?>(foundUser);
    }

    public IEnumerable<UserDto> GetUsersWithEmail(string email)
    {
        var userQuery = new FilterUserQuery(_mapper, _userQuery);
        return userQuery.Execute(new UserFilterDto { Email = email, SortAscending = true });
    }

    public void RegisterUser(UserCreateDto userCreateDto)
    {
        var passwordSalt = _securityHelper.GenerateSalt();
        var passwordHash = _securityHelper.HashPassword(userCreateDto.Password, passwordSalt);
        
        var user = new User { 
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

    public void Insert(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        using var uow = _unitOfWorkFactory();
        _userRepository.Insert(user);
        uow.Commit();
    }

    public void Update(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        using var uow = _unitOfWorkFactory();
        _userRepository.Update(user);
        uow.Commit();
    }

    //delete all reservations for this user
    public void Delete(Guid id)
    {
        using var uow = _unitOfWorkFactory();
        _userRepository.Delete(id);
        uow.Commit();
    }
}