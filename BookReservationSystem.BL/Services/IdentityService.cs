using AutoMapper;
using BookReservationSystem.BL.Helpers;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Identity;

namespace BookReservationSystem.BL.Services;

public class IdentityService : IIdentityService
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly ISecurityHelper _securityHelper;
    private readonly IMapper _mapper;
    
    public IdentityService(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper, ISecurityHelper securityHelper)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _mapper = mapper;
        _securityHelper = securityHelper;
    }

    public async Task Register(UserCreateDto model)
    {
        var newUser = _mapper.Map<User>(model);
        newUser.PasswordSalt = _securityHelper.GenerateSalt();
        var passwordHash = _securityHelper.HashPassword(model.Password, newUser.PasswordSalt);

        var createResult = await _userManager.CreateAsync(newUser, passwordHash).ConfigureAwait(false);
        if (!createResult.Succeeded) return;
        
        var user = await _userManager.FindByNameAsync(model.UserName).ConfigureAwait(false);
        await _userManager.AddToRoleAsync(user, "User").ConfigureAwait(false);
        if (model.IsAdmin)
        {
            await _userManager.AddToRoleAsync(user, "Admin").ConfigureAwait(false);
        }
        await _signInManager.SignInAsync(user, true).ConfigureAwait(false);
    }

    public async Task Login(LoginDto model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName).ConfigureAwait(false);
        if (user is null) return;
        
        var passwordHash = _securityHelper.HashPassword(model.Password, user.PasswordSalt);
        if (!await _userManager.CheckPasswordAsync(user, passwordHash).ConfigureAwait(false)) return;

        await _signInManager.SignOutAsync().ConfigureAwait(false);
        var loggedIn = await _signInManager
            .PasswordSignInAsync(model.UserName, passwordHash, true, false)
            .ConfigureAwait(false);
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync().ConfigureAwait(false);
    }
}