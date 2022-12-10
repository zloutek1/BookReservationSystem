using BookReservationSystem.BL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookReservationSystem.FE.Pages.Identity;

public class Logout : PageModel
{
    private readonly IIdentityService _identityService;
    
    public Logout(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        await _identityService.Logout();
        return Redirect("~/");
    }
}