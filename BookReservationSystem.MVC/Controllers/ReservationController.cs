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
    public IActionResult Index(Guid bookId)
    {
        var reservation = new ReservationCreateDto
        {
            BookId = bookId,
            CustomerName = User.Identity?.Name!
        };
        return View(reservation);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Index(ReservationCreateDto reservation)
    {
        if (!ModelState.IsValid)
        {
            return View(reservation);
        }

        _reservationService.Insert(reservation);
        return RedirectToAction("Profile", "User");
    }
}