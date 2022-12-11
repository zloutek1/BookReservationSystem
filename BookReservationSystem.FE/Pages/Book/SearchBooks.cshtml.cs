using BookReservationSystemMVC.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookReservationSystem.FE.Pages.Book
{
    public class SearchBooks : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public SearchBooks(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // [BindProperty]  // POST-Only
        [BindProperty(SupportsGet = true)]
        public int MyProperty { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }
    }
}