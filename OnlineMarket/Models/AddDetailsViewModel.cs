using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMarket.DAL;
namespace OnlineMarket.Models
{
    public class AddDetailsViewModel
    {
        public Item ItemDetails { get; set; }
        public Seller SellerDetails { get; set; }
        public List<Item> SimilarItems { get; set; }
        public List<Item> ItemsBySeller { get; set; }

    }
}