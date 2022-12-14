using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class ReservationCreateDto
{
    [Required]
    [DataType(DataType.Date)]
    public DateTime ReservationDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }

    public Guid LibraryId { get; set; }
    public Guid BookId { get; set; }
    public string CustomerName { get; set; }
}
