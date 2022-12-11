using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookReservationSystem.FE.Pages.User
{
    public class ProfileView : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public ProfileView(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        // [BindProperty]  // POST-Only
        [BindProperty(SupportsGet = true)]
        public int MyProperty { get; set; }

        public void OnGet()
        {

        }
    }
}