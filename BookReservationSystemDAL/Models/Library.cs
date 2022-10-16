using System.ComponentModel.DataAnnotations.Schema;

namespace BookReservationSystemDAL.Models;

public class Library : BaseEntity
{
    public Guid AddressId { get; set; }

    [ForeignKey(nameof(AddressId))]
    public virtual Address? Address { get; set; }

    public virtual List<BookQuantity> Books { get; set; } = new List<BookQuantity>();

    public virtual List<Reservation> Reservations { get; set; } = new List<Reservation>();
}