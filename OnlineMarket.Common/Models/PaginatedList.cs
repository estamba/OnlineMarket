using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Common.Models
{
    public class PaginatedList<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int ActualSize { get; set; }
        public List<T> Results { get; set; }
    }
}
