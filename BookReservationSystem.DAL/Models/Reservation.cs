using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReservationSystem.DAL.Models;

public class Reservation : BaseEntity
{
    [Required]
    public DateTime ReservationDate { get; set; }

    public DateTime? DueDate { get; set; }
    public DateTime? PickupDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    [Required]
    public Guid LibraryId { get; set; }

    [ForeignKey(nameof(LibraryId))] 
    public virtual Library Library { get; set; } = null!;

    [Required]
    public Guid BookId { get; set; }

    [ForeignKey(nameof(BookId))] 
    public virtual Book Book { get; set; } = null!;

    [Required]
    public Guid CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))] 
    public virtual User Customer { get; set; } = null!;
}
