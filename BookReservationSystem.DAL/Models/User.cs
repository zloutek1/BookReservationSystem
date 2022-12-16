using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BookReservationSystem.DAL.Models;

public class User : IdentityUser<Guid>
{

    [Required]
    [MaxLength(64)]
    public string FirstName { get; set; } = null!;

    [Required] 
    [MaxLength(64)] 
    public string LastName { get; set; } = null!;
    
    
    public virtual List<Review> Reviews { get; set; } = new();

    public virtual List<Reservation> Reservations { get; set; } = new();
}
