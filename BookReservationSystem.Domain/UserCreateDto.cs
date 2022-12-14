using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class UserCreateDto
{
    [Required]
    [StringLength(64)]
    [Display(Name = "FirstName")]
    public string FirstName { get; set; }   
    
    [Required]
    [StringLength(64)]
    [Display(Name = "LastName")]
    public string LastName { get; set; }  
    
    [Required]
    [StringLength(64)]
    [Display(Name = "Username")]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "E-mail")]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 8)]
    [RegularExpression(@"([a-zA-Z]+[^a-zA-Z]+|[^a-zA-Z]+[a-zA-Z]+).*", ErrorMessage = "The password is not complex enough")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }

    public bool IsAdmin { get; set; }
    
    public string? ReturnUrl { get; set; }
}