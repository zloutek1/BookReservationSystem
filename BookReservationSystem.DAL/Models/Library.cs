using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReservationSystem.DAL.Models;

public class Library : BaseEntity
{
    [Required]
    public string Name { get; set; } = null!;
    
    [Required]
    public Guid AddressId { get; set; }

    [ForeignKey(nameof(AddressId))]
    public virtual Address? Address { get; set; }

    public virtual List<BookQuantity> Books { get; set; } = new();

    public virtual List<Reservation> Reservations { get; set; } = new();
}
