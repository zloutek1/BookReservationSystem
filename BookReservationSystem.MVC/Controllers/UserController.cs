using BookReservationSystem.BL.IServices;
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
    public async Task<IActionResult> Profile()
    {
        var username = User.Identity?.Name;
        if (username == null)
        {
            return View("Error");
        }
            
        var profile = await _userService.FindByUsername(username);
        return profile == null ? View("Error") : View("Profile", profile);
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
}