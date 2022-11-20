using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.UnitOfWork;
using BookReservationSystem.BL.Helpers;
using System.Security.Cryptography;

namespace BookReservationSystem.BL.Services;

public class UserService: ICrudService<LibraryDto>
{
    private readonly IMapper _mapper;
    private readonly IUserUnitOfWork _libraryUnitOfWork;
    
    public UserService(IMapper mapper, IUserUnitOfWork userUnitOfWork)
    {
        _mapper = mapper;
        _userUnitOfWork = userUnitOfWork;
    }
    
    public IEnumerable<UserDto> FindAll()
    {
        var foundUsers = _userUnitOfWork.UserRepository.FindAll();
        return _mapper.Map<IEnumerable<UserDto>>(foundUsers);
    }

    public UserDto? FindById(Guid id)
    {
        var foundUser = _userUnitOfWork.UserRepository.FindById(id);
        return _mapper.Map<UserDto?>(foundUser);
    }

    public IEnumerable<UserDto> GetUsersWithEmail(string email)
    {
        userQueryObject = new UserQuery(_mapper, _userUnitOfWork);
        return userQueryObject.Execute(new UserFilterDto() { Email = email, SortAscending = true }).Items;
    }

    public void RegisterUser(UserCreateDto userDto)
    {
        SecurityHelper ph = new SecurityHelper();
        string passwordSalt = ph.GenerateSalt();
        string passwordHash = ph.HashPassword(password);
        User user = new User() { Email = userDto.Email, 
                                FirstName = userDto.FirstName, 
                                LastName = userDto.LastName,
                                PasswordSalt = passwordSalt, 
                                Password = passwordHash });
        _userUnitOfWork.UserRepository.Insert(user);
    }

    public void Insert(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        _userUnitOfWork.UserRepository.Insert(user);
    }

    public void Update(UserDto userDto)
    {
        var user = _mapper.Map<Library>(userDto);
        _userUnitOfWork.UserRepository.Update(user);
    }

    public void Delete(Guid id)
    {
        _userUnitOfWork.UserRepository.Delete(id);
    }
}