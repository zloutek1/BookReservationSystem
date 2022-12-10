using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Domain
{
    public class ReviewUserFilterDto
    {
        public int? RequestedPageNumber { get; set; }
        public int PageSize { get; set; }

        public string SortCriteria { get; set; }
        public bool SortAscending { get; set; }

        public string Email { get; set; }
    }
}
