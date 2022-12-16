using BookReservationSystem.BL.Exceptions;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookReservationSystem.MVC.Controllers;

public class ReservationController: Controller
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
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

        _reservationService.Insert(reservation);
        return RedirectToAction("Profile", "User");
    }
}