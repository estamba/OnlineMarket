using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineMarket.Common.Models;
using OnlineMarket.Services;
using OnlineMarket.Repositories;
using OnlineMarket.Common.Utilities;
using OnlineMarket.Validations;
using OnlineMarket.Models;
using OnlineMarket.DAL;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNet.Identity;

namespace OnlineMarket.Controllers
{

    public class ItemController : Controller
    {
        private CategoryService _CategoryService;
        private MetadataService _MetadataService;
        private ItemService _ItemService;
        private DocumentService _DocumentService;
        private UnitOfWork _unitOfWork;
        CurrentUser _currentUser;

        public ItemController(CategoryService categoryService, MetadataService metadataService, 
            ItemService itemService,UnitOfWork unitOfWork,DocumentService documentService,CurrentUser currentUser)
        {
            this._CategoryService = categoryService;
            this._MetadataService = metadataService;
            this._ItemService = itemService;
            this._DocumentService = documentService;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;

        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Add()
        {
            var categoryList = await _CategoryService.GetCategoriesAsync();
            ViewBag.Categories = categoryList.Select(a => new
            {
                Id = a.Id,
                Name = a.Name,
                ParentId = a.ParentId
            });

            var cityList = await _MetadataService.GetCitiesAync();
            ViewBag.Cities = cityList.Select(a => new
            {
                Id = a.ID,
                Name = a.Name
            });

            var locationList = await _MetadataService.GetLocationsAsync();
            ViewBag.Locations = locationList.Select(a => new
            {
                Id = a.Id,
                Name = a.Name,
                CityId = a.CityId
            });

            ViewBag.Seller = await _unitOfWork.SellerRepository.GetSellerByAccountIdAsync(User.Identity.GetUserId());

            return View();
        }
        public ActionResult Edit(int ?  Id)
        {

            if(Id == null)
            {
                return RedirectToAction("MyAds");

            }
            Item item = _ItemService.GetItemByID(Id);
            EditItemViewModel model = new EditItemViewModel()
            {
                Id = item.Id,
                description = item.Description,
                price = item.Price.Value,
                status = item.ItemStatus,
                title = item.Name
               

                
            };

            model.StatusList = GetItemStatusSelectList();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(EditItemViewModel model)
        {
            if(!ModelState.IsValid)
            {
                model.StatusList = GetItemStatusSelectList();
                return View(model);
            }

            Item item = _ItemService.GetItemByID(model.Id);
            item.Description = model.description;
            item.Price = model.price;
            item.ItemStatus = model.status;
            _unitOfWork.SaveChanges();
            return RedirectToAction("MyAds");
            
        }
        [Authorize]
        public async Task<ActionResult> MyAds()
        {

         var seller=  await _unitOfWork.SellerRepository.GetSellerByAccountIdAsync(User.Identity.GetUserId());

            int sellerId = 2;// Todo: remove later
         List<Item> model =   _unitOfWork.ItemRepository.Get(x => x.IsDeleted == false && x.SellerID == sellerId);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(ItemPostViewModel model, List<HttpPostedFileBase> images)
        {
            List<Document> documents = new List<Document>();
            foreach(var img in images)
            {
                Document document = new Document()
                {
                    Id = Guid.NewGuid(),
                    ContentType = img.ContentType,
                    Extension = Path.GetExtension(img.FileName),
                    Name = img.FileName,
                    Content = await img.InputStream.ToByteArrayAsync()
                };

                documents.Add(document);
            }

            Seller seller = await _unitOfWork.SellerRepository.GetSellerByAccountIdAsync(User.Identity.GetUserId());

            PostAdModel postedAd = new PostAdModel()
            {
                CategoryId = model.CategoryId.Value,
                Description = model.Description,
                Title = model.Name,
                LocationId = model.LocationId.Value,
                Price = model.Price.Value,
                Images = documents,
                SellerId = seller.Id
            };
            await _ItemService.PostItemAsync(postedAd);

            return RedirectToAction("Add");
        }
        public ActionResult Details(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return RedirectToAction("Index", "Home");
            }

            AddDetailsViewModel model = new AddDetailsViewModel();
            model.ItemDetails = _ItemService.GetItemByID(int.Parse(Id));
            model.SimilarItems = _ItemService.GetSimilarItem(model.ItemDetails.CategoryID);
            model.ItemsBySeller = _ItemService.GetItemsBySeller(model.ItemDetails.SellerID);
            Item item = _ItemService.GetItemByID(int.Parse(Id));
            Seller seller = item.Seller;
            ViewBag.seller = seller;
         
            return View(model);
        }
        public ActionResult Category(string category)
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int Id)
        {
            Item item = _ItemService.GetItemByID(Id);
            if(item == null)
            {
                return HttpNotFound();
            }
            item.IsDeleted = true;
            _unitOfWork.SaveChanges();
             item = _ItemService.GetItemByID(Id);

            _unitOfWork.LogQueries();
            return Json(true);
        }

        [HttpPost]

        public void UpdateViewCount(int? Id)
        {
            if (Id == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(_currentUser.visitorId))
            {
                _currentUser.visitorId = Guid.NewGuid().ToString();
            }

            _ItemService.UpdateViewCount(Id.Value);
        }
        public async Task<ActionResult> Search(PostedAdSearchFilter filter,int page =1, string viewStyle = "list")
        {
            page--;
            PaginatedList<PostedAdListItem> model = new PaginatedList<PostedAdListItem>();
            model = await _ItemService.SearchPostedAdAsync(filter, page, 5);
            var categoryList = await _CategoryService.GetMainCategoriesAsync();
            var locationList = await _MetadataService.GetLocationsAsync();

            ViewBag.Categories = categoryList.Select(a => new
            {
                Id = a.Id,
                Name = a.Name,
                ParentId = a.ParentId
            });
            ViewBag.Locations = locationList.Select(a => new
            {
                Id = a.Id,
                Name = a.Name
            });
            model.PageIndex++;
            ViewBag.viewStyle = viewStyle;
           

            return View(model);
        }

        public ActionResult CarouselTest()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Image(Guid id)
        {
            var document = await _DocumentService.GetDocumentAsync(id);
            if (document != null && document.ContentType.Contains("image/"))
            {
                MemoryStream content = new MemoryStream(document.Content);
                return new FileStreamResult(content, document.ContentType);
            }
            return HttpNotFound();
        }
        public List<SelectListItem> GetItemStatusSelectList()
        {

            var itemStatusList = _ItemService.GetItemStatusList();
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach ( var itemStatus in itemStatusList)
            {
                selectList.Add(new SelectListItem() { Text = itemStatus.Name, Value = itemStatus.Name });
            }

            return selectList;

        }
    }
}