using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Identity;

namespace BookReservationSystem.BL.IServices;

public interface IIdentityService
{
    Task Register(UserCreateDto model);
    Task<SignInResult> Login(LoginDto model);
    Task Logout();
}