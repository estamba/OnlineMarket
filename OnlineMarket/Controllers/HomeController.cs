using OnlineMarket.Models;
using OnlineMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineMarket.Controllers
{
    public class HomeController : Controller
    {
        private CategoryService _CategoryService;
        private MetadataService _MetadataService;
        private ItemService _ItemService;

        public HomeController(CategoryService categoryService, MetadataService metadataService, ItemService itemService)
        {
            this._CategoryService = categoryService;
            this._MetadataService = metadataService;
            this._ItemService = itemService;
        }
        
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var CategoryList = await _CategoryService.GetMainCategoriesAsync();
            var locationList = await _MetadataService.GetLocationsAsync();
            var LatestPostedAdList = await _ItemService.GetLatestPostedAdsAsync(6);

            HomeViewModel model = new HomeViewModel()
            {
                Categories = CategoryList,
                 locations = locationList,
                LatestPostedAds = LatestPostedAdList
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
    }
}