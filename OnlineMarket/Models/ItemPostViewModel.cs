using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMarket.Models
{
    public class ItemPostViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [AllowHtml]
        public string Description { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public int? LocationId { get; set; }
        [Required]
        public decimal? Price { get; set; }
        public int? SellerId { get; set; }
        public string SellerFirstName { get; set; }
        public string SellerLastName { get; set; }
        public string SellerPhone { get; set; }
    }
}