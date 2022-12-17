using BookReservationSystem.BL.IServices;
using BookReservationSystem.BL.Services;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BookReservationSystem.MVC.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Profile(string ?username)
    {
        username ??= User.Identity?.Name;

        if (username == null)
        {
            return View("Error");
        }
            
        var profile = await _userService.FilterUsers(new UserFilterDto { UserName = username });
        return profile.FirstOrDefault() == null ? View("Error") : View("Profile", profile.FirstOrDefault());
    }

    [HttpPost("EditProfile")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditProfile(UserEditDto user)
    {
        if (!ModelState.IsValid)
        {
            return View("EditProfile");
        }

        try
        {
            await _userService.Update(user);
            return RedirectToAction("Profile", "User");
        }
        catch (Exception)
        {
            ModelState.AddModelError("EmailAddress", "Account with that email address already exists!");
            return View("EditProfile");
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userService.Delete(id);
        return RedirectToAction("Index", "User");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var users = await _userService.FindAll();
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserFilterDto filter)
    {
        if (!ModelState.IsValid)
        {
            return View("Error");
        }

        var users = await _userService.FilterUsers(filter);
        return View(users);
    }
}