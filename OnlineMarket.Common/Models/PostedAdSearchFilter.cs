using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Common.Models
{
    public class PostedAdSearchFilter
    {
        public string Title { get; set; }
        public int page { get; set; } = 0;
        public int? CategoryId { get; set; }
        public int? LocationId { get; set; }
        public decimal? StartPrice { get; set; }
        public decimal? EndPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? SellerId { get; set; }
        public SortOrderType? SortBy { get; set; }
        public SortDirection? SortDirection { get; set; }
    }
}
