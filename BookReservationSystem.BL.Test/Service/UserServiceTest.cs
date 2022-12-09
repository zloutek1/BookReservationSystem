using AutoMapper;
using BookReservationSystem.BL.Helpers;
using BookReservationSystem.BL.Services;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Moq;

namespace BookReservationSystem.BL.Test.Service;

public class UserServiceTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _uowMock;
    private readonly Mock<IRepository<User>> _userRepositoryMock;
    private readonly Mock<SecurityHelper> _securityHelperMock;
    private readonly Mock<IQuery<User>> _userQueryMock;

    public UserServiceTest(IMapper mapper)
    {
        _mapper = mapper;
        _uowMock = new Mock<IUnitOfWork>();
        _userRepositoryMock = new Mock<IRepository<User>>();
        _securityHelperMock = new Mock<SecurityHelper>();
        _userQueryMock = new Mock<IQuery<User>>();
    }

    [Fact]
    public void RegisterUser_registers()
    {
        var userCreateDto = new UserCreateDto
        {
            Email = "a@b",
            FirstName = "First",
            LastName = "Last",
            Password = "NotHashedPassword"
        };
        
        _securityHelperMock
            .Setup(x => x.GenerateSalt())
            .Returns("mySalt");
        _securityHelperMock
            .Setup(x => x.HashPassword(It.IsAny<string>(), It.IsAny<string>()))
            .Returns("Hashed123456");
        
        var userService = new UserService(_mapper, () => _uowMock.Object, _userRepositoryMock.Object,
            _securityHelperMock.Object, _userQueryMock.Object);

        userService.RegisterUser(userCreateDto);
        
        _userRepositoryMock.Verify(mock => 
            mock.Insert(
                It.Is<User>(user => user.PasswordHash == "Hashed123456")), 
            Times.Once());
        _uowMock.Verify(mock => mock.Commit(), Times.Once());
    }
}