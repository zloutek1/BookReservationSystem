using BookReservationSystem.BL.Exceptions;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.BL.Services;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;


namespace BookReservationSystem.MVC.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    private IToastNotification _toastNotification;

    public UserController(IUserService userService, IToastNotification toastNotification)
    {
        _userService = userService;
        _toastNotification = toastNotification;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Profile(string? username)
    {
        username ??= User.Identity?.Name;
        var profile = (await _userService.FilterUsers(new UserFilterDto { UserName = username })).FirstOrDefault();

        if (profile == null)
        {
            _toastNotification.AddErrorToastMessage($"User with {username} not found");
            return RedirectToAction("Index", "Home");
        }
        
        return View("Profile", profile);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Edit(Guid id)
    {
        var user = await _userService.FindById(id);
        return View(user);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Edit(UserDto updateDto)
    {
        if (!ModelState.IsValid)
        {
            return View(updateDto);
        }

        try
        {
            await _userService.Update(updateDto);
        }
        catch (ServiceException ex)
        {
            ModelState.AddModelError("message", "Could not update: "+ ex.Message);
            return View(updateDto);
        }

        return RedirectToAction("Profile", "User", new { username = updateDto.UserName });
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _userService.Delete(id);
        }
        catch (ServiceException ex)
        {
            _toastNotification.AddErrorToastMessage(ex.Message);
        }

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
        var users = await _userService.FilterUsers(filter);
        return View(users);
    }
}