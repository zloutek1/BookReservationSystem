using BookReservationSystem.BL.IServices;
using BookReservationSystem.MVC.Models;
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
    public IActionResult Profile()
    {
        var username = User.Identity?.Name;
        if (username == null)
        {
            return View("Error");
        }
            
        var profile = _userService.FindByUsername(username);
        return profile == null ? View("Error") : View("Profile", profile);
    }

    //[HttpGet("EditProfile")]
    //public IActionResult EditProfile(Guid userId)
    //{
    //if (!User.Identity.IsAuthenticated)
    // {
    //    return RedirectToAction("Login", "User");
    //}
    //  var profile = _userService.FindById(userId);
    //var editProfileModel = new EditProfileModel(profile);
    //return View(editProfileModel);
    //}

    [HttpPost("EditProfile")]
    [ValidateAntiForgeryToken]
    public IActionResult EditProfile(EditProfileModel user)
    {
        if (!ModelState.IsValid)
        {
            return View("EditProfile");
        }

        try
        {
            _userService.Update(user.ConvertToProfileDto());
            return RedirectToAction("Profile", "User");
        }
        catch (Exception)
        {
            ModelState.AddModelError("EmailAddress", "Account with that email address already exists!");
            return View("EditProfile");
        }
    }
}