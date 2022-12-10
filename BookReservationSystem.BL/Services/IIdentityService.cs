using BookReservationSystem.Domain;

namespace BookReservationSystem.BL.Services;

public interface IIdentityService
{
    Task Register(UserCreateDto model);
    Task Login(LoginDto model);
    Task Logout();
}