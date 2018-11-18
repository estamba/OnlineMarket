using OnlineMarket.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Common.Models
{
    public class PostAdModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int LocationId { get; set; }
        public int SellerId { get; set; }
        public List<Document> Images { get; set; }
    }
}
