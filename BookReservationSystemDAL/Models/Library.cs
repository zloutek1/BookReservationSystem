using System.ComponentModel.DataAnnotations.Schema;

namespace BookReservationSystemDAL.Models;

public class Library : BaseEntity
{
    public Guid AddressId { get; set; }

    [ForeignKey(nameof(AddressId))]
    public virtual Address? Address { get; set; }

    public virtual List<BooksInLibrary> Books { get; set; } = new List<BooksInLibrary>();

    public virtual List<Reservation> Reservations { get; set; } = new List<Reservation>();
}