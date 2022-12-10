using System.ComponentModel.DataAnnotations;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookReservationSystem.FE.Pages.Identity;

[ValidateAntiForgeryToken]
public class Login : PageModel
{
    [BindProperty]
    public LoginDto Model { get; set; } = null!;

    public string? ReturnUrl { get; set; }
    
    
    
    private readonly IIdentityService _identityService;
    
    public Login(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        ReturnUrl ??= Url.Content("~/");
        await _identityService.Login(Model);
        return Redirect(ReturnUrl);
    }
}