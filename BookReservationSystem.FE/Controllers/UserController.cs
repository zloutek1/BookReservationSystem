using BookReservationSystem.BL.IServices;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.FE.Models;
using Microsoft.AspNetCore.Mvc;


namespace BookReservationSystem.FE.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Profile")]
        public IActionResult Profile()
        {
            //try
            //{
                var profileModel = new ProfileModel();

                int userId = int.Parse(User.Identity.Name); //how do I get id?
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(userId).CopyTo(bytes, 0);
                var guid = new Guid(bytes);
            profileModel.Profile = _userService.FindById(guid);
                return View(profileModel);
            //}
            //catch (Exception)
            //{
            //    return RedirectToAction("Login", "User");
            //}
        }
    }
}
