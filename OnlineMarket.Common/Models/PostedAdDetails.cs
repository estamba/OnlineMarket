using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Common.Models
{
    public class PostedAdDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public int LocationId { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string SellerPhone { get; set; }
        public Guid CoverPhotoId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public int PictureCount { get; set; }
        public List<Guid> Pictures { get; set; }
    }
}
