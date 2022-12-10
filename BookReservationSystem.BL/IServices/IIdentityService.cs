using BookReservationSystem.Domain;

namespace BookReservationSystem.BL.IServices;

public interface IIdentityService
{
    Task Register(UserCreateDto model);
    Task Login(LoginDto model);
    Task Logout();
}