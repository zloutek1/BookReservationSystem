using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BookReservationSystem.DAL.Models;

public class User : IdentityUser<Guid>
{

    [Required]
    [MaxLength(64)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(64)]
    public string LastName { get; set; }
    
    
    [Required]
    [MaxLength(128)]
    public string PasswordSalt { get; set; }
}
