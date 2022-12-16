using BookReservationSystem.BL.Exceptions;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BookReservationSystem.MVC.Controllers;

public class ReservationController: Controller
{
    private readonly IReservationService _reservationService;
    private readonly IToastNotification _toastNotification;

    public ReservationController(IReservationService reservationService, IToastNotification toastNotification)
    {
        _reservationService = reservationService;
        _toastNotification = toastNotification;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Index(Guid id)
    {
        var reservation = new ReservationCreateDto
        {
            BookId = id,
            UserName = User.Identity?.Name!
        };
        return View(reservation);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Index(ReservationCreateDto createDto)
    {
        if (!ModelState.IsValid)
        {
            return View(createDto);
        }

        await _reservationService.Insert(createDto);
        return RedirectToAction("Profile", "User");
    }

    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Pickup(Guid id)
    {
        try
        {
            await _reservationService.PickupBook(id);
            return RedirectToAction("Profile", "User");
        }
        catch (ServiceException ex)
        {
            _toastNotification.AddErrorToastMessage(ex.Message);
            return RedirectToAction("Profile", "User");
        }
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Return(Guid id)
    {
        try
        {
            await _reservationService.ReturnBook(id);
            return RedirectToAction("Profile", "User");
        }
        catch (ServiceException ex)
        {
            _toastNotification.AddErrorToastMessage(ex.Message);
            return RedirectToAction("Profile", "User");
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _reservationService.Delete(id);
        return RedirectToAction("Profile", "User");
    }
}