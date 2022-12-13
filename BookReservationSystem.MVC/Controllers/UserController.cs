using BookReservationSystem.BL.IServices;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;


namespace BookReservationSystem.MVC.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Profile")]
        public IActionResult ProfileView()
        {
            //try
            //{
                var profileModel = new ProfileModel();
            //kill me
            profileModel.Profile = new UserProfileDto { Email = "peepo", FirstName = "Peepo", LastName = "pepe", Id = Guid.NewGuid(), Reservations = new List<ReservationDto> { }, Reviews = new List<ReviewDto> { } };

            //profileModel.Profile = _userService.FindById(guid); how the fuck
                return View(profileModel);
            //}
            //catch (Exception)
            //{
            //    return RedirectToAction("Login", "User");
            //}
        }
    }
}
