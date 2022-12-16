using AutoMapper;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Identity;

namespace BookReservationSystem.BL.Services;

public class IdentityService : IIdentityService
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    
    public IdentityService(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task Register(UserCreateDto model)
    {
        var newUser = _mapper.Map<User>(model);
        var createResult = await _userManager.CreateAsync(newUser, model.Password).ConfigureAwait(false);
        if (!createResult.Succeeded) return;

        var user = await _userManager.FindByNameAsync(model.UserName).ConfigureAwait(false);
        await _userManager.AddToRoleAsync(user, "User").ConfigureAwait(false);
        if (model.IsAdmin)
        {
            await _userManager.AddToRoleAsync(user, "Admin").ConfigureAwait(false);
        }
        await _signInManager.SignInAsync(user, true).ConfigureAwait(false);
    }

    public async Task<SignInResult> Login(LoginDto model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName).ConfigureAwait(false);
        if (user is null) return SignInResult.Failed;
        
        if (!await _userManager.CheckPasswordAsync(user, model.Password).ConfigureAwait(false)) 
            return SignInResult.Failed;

        await _signInManager.SignOutAsync().ConfigureAwait(false);
        return await _signInManager
            .PasswordSignInAsync(model.UserName, model.Password, true, false)
            .ConfigureAwait(false);
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync().ConfigureAwait(false);
    }
}