using OnlineMarket.Common.Models;
using OnlineMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineMarket.Controllers
{
    public class SellerController : Controller
    {

        ItemService _itemService;
        public SellerController( ItemService itemService)
        {
            _itemService = itemService;
        }
        // GET: Seller
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public async Task <ActionResult> AddListing(PostedAdSearchFilter filter, int page = 1)
        {
            PaginatedList<PostedAdListItem> model = new PaginatedList<PostedAdListItem>();
            model = await _itemService.SearchPostedAdAsync(filter, page, 5);

            return View(model);
        }
    }
}