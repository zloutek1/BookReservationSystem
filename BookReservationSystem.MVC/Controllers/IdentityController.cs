using BookReservationSystem.BL.IServices;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BookReservationSystem.MVC.Controllers;

public class IdentityController : Controller
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        if (User.Identity is { IsAuthenticated: true })
        {
            return RedirectToAction("Index", "Home");
        }

        var login = new LoginDto { ReturnUrl = returnUrl };
        return View(login);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        if (!ModelState.IsValid)
        {
            return View(loginDto);
        }

        loginDto.ReturnUrl ??= Url.Content("~/");
        var loggedIn = await _identityService.Login(loginDto);

        if (loggedIn.Succeeded)
        {
            return Redirect(loginDto.ReturnUrl);
        }
        
        ModelState.TryAddModelError("message", "Invalid credentials");
        return View();
    }
    
    [HttpGet]
    public IActionResult Register(string? returnUrl)
    {
        if (User.Identity is { IsAuthenticated: true })
        {
            return RedirectToAction("Index", "Home");
        }

        var createDto = new UserCreateDto { ReturnUrl = returnUrl };
        return View(createDto);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserCreateDto user)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        user.ReturnUrl ??= Url.Content("~/");
        await _identityService.Register(user);
        return Redirect(user.ReturnUrl);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _identityService.Logout();
        return RedirectToAction("Index", "Home");
    }
}