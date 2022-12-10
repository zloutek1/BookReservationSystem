using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookReservationSystemMVC.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public ProfileModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // [BindProperty]  // POST-Only
        [BindProperty(SupportsGet = true)]
        public int MyProperty { get; set; }

        public void OnGet()
        {

        }
    }
}
