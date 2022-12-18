using BookReservationSystem.BL.Exceptions;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BookReservationSystem.MVC.Controllers;

public class IdentityController : Controller
{
    private readonly IIdentityService _identityService;
    private readonly IToastNotification _toastNotification;

    public IdentityController(IIdentityService identityService, IToastNotification toastNotification)
    {
        _identityService = identityService;
        _toastNotification = toastNotification;
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

        if (!loggedIn.Succeeded)
        {
            ModelState.TryAddModelError("message", "Invalid credentials");
            return View();
        }

        return Redirect(loginDto.ReturnUrl);
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

        try
        {
            await _identityService.Register(user);
        }
        catch (ServiceException ex)
        {
            ModelState.TryAddModelError("message", "Could not register: " + ex.Message);
            return View();
        }

        return Redirect(user.ReturnUrl);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await _identityService.Logout();
        }
        catch (ServiceException ex)
        {
            _toastNotification.AddErrorToastMessage(ex.Message);
        }

        return RedirectToAction("Index", "Home");
    }
}