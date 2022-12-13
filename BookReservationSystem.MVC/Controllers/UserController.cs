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
        public IActionResult ProfileView(Guid userId)
        {
            try
            {
                var profileModel = new ProfileModel();
                profileModel.Profile = _userService.FindById(userId);
                return View(profileModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "User");
            }
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
}
