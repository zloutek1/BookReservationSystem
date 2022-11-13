namespace BookReservationSystem.Domain;

public class BookFilterDto
{
    public int? RequestedPageNumber { get; set; }
    public int PageSize { get; set; }
    
    public string SortCriteria { get; set; }
    public bool SortAscending { get; set; }
    
    public string Name { get; set; }
}