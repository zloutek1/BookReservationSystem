using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.BL.DTOs
{
    public class BookNameFilterDTO
    {
        public string Name { get; set; }
        public string SortCriteria { get; set; }
        public bool SortAscending { get; set; }
        public int? RequestedPageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
