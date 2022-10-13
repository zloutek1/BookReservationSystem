namespace BookReservationSystemDAL.Models;

public class Role : BaseEntity
{
    public string Name { get; set; }

    public virtual List<User> Users { get; set; } = new List<User>();
}