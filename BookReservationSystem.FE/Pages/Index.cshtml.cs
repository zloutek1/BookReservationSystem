using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookReservationSystemMVC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
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