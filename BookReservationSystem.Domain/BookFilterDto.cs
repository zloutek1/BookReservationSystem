using BookReservationSystem.DAL.Models;

namespace BookReservationSystem.Domain;

public class BookFilterDto
{
    public int? RequestedPageNumber { get; set; }
    public int PageSize { get; set; }

    public string SortCriteria { get; set; }
    public bool SortAscending { get; set; }

    public string Name { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public long Isbn { get; set; }

    public bool SortByRating { get; set; }
    public bool OnlyAvailable { get; set; }
}