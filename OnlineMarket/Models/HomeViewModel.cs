using OnlineMarket.Common.Models;
using OnlineMarket.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineMarket.Models
{
    public class HomeViewModel
    {
        public List<Category> Categories { get; set; }
        public List<PostedAdListItem> LatestPostedAds { get; set; }
        public List<PostedAdListItem> FeaturedAd { get; set; }
        public List<Location> locations { get; set; }
    }
}