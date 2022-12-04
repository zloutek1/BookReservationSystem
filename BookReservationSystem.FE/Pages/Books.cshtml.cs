using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookReservationSystemMVC.Pages
{
    public class BooksModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public BooksModel(ILogger<IndexModel> logger)
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