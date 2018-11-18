using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.DAL;
using OnlineMarket.Repositories;
using OnlineMarket.Common.Models;
using System.Web;
using System.Data.SqlClient;
using System.Runtime.Caching;

namespace OnlineMarket.Services
{
    public class ItemService
    {
        private UnitOfWork _UnitOfWork;
        MemoryCache viewCountCache = MemoryCache.Default;
        CurrentUser currentUser;

        public ItemService(UnitOfWork uow,CurrentUser currentUser)
        {
            this._UnitOfWork = uow;
            this.currentUser = currentUser;
        }

        public async Task<Item> PostItemAsync(PostAdModel model)
        {
            DateTime time = DateTime.Now;

            Item item = new Item()
            {
                CategoryID = model.CategoryId,
                Name = model.Title,
                Description = model.Description,
                IsDeleted = false,
                Price = model.Price,
                SellerID = model.SellerId,
                LocationID = model.LocationId,
                Documents = model.Images,
                CreatedDate = time,
                CreatedDateUtc = time.ToUniversalTime(),
                CoverPhotoId = model.Images[0].Id,
                PictureCount = model.Images.Count
            };

            _UnitOfWork.ItemRepository.Insert(item);
            await _UnitOfWork.SaveChangesAsync();

            return item;
        }
        public Item GetItemByID(object Id)
        {
            return _UnitOfWork.ItemRepository.GetByID(Id);
        }
        public void UpdateViewCount(int Id)
        {
            Item item = _UnitOfWork.ItemRepository.GetByID(Id);
            if(item == null)
            {
                return;
            }
            string key = currentUser.visitorId + Id;

            if(!IsInViewCountCache(key))
            {
                item.ViewCount++;

                _UnitOfWork.SaveChanges();

                AddInViewCountCache(key);
            }

        }
        public List<Item>GetSimilarItem(int? categoryId)
        {

            return _UnitOfWork.ItemRepository.Get(x => x.CategoryID == categoryId);
        }
        public List<Item>GetItemsBySeller(int ? sellerId)
        {
            return _UnitOfWork.ItemRepository.Get(x => x.SellerID == sellerId);
        }
        public async Task<List<PostedAdListItem>> GetLatestPostedAdsAsync(int size)
        {
            PostedAdSearchFilter filter = new PostedAdSearchFilter()
            {
                SortBy = SortOrderType.date,
                SortDirection = SortDirection.desc
            };
            var List = await _UnitOfWork.ItemRepository.SearchPostedAdAsync(filter, 0, size);
            return List.Results;
        }

        public Task<PaginatedList<PostedAdListItem>> SearchPostedAdAsync(PostedAdSearchFilter filter, int pageIndex, int pageSize)
        {
            return _UnitOfWork.ItemRepository.SearchPostedAdAsync(filter, pageIndex, pageSize);
        }

        public Task<PostedAdDetails> GetItemByIDAsync(int id)
        {
            return _UnitOfWork.ItemRepository.GetPostedAdDetailsByIDAsync(id);
        }
        public  List <ItemStatu> GetItemStatusList()
        {
            return _UnitOfWork.ItemRepository.GetStatusList();
        }
        private bool IsInViewCountCache(string key)
        {
            string value = viewCountCache.Get(key) as string;

            return (!string.IsNullOrEmpty(value));
        }
        private void AddInViewCountCache(string key)
        {
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddDays(1);
            viewCountCache.Add(key, key, cacheItemPolicy);
        }
    }

}
