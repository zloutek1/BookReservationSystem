namespace BookReservationSystem.Domain;

public class LibraryAddressFilterDto
{
    public AddressDto Address { get; set; }
    public string SortCriteria { get; set; }
    public bool SortAscending { get; set; }
    public int? RequestedPageNumber { get; set; }
    public int PageSize { get; set; }
}