namespace BookReservationSystem.Domain;

public class UserFilterDto
{
    public int? RequestedPageNumber { get; set; }
    public int PageSize { get; set; }

    public string? SortCriteria { get; set; }
    public bool SortAscending { get; set; }

    public string? Name { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
}