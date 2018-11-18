using OnlineMarket.Common.Models;
using OnlineMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace OnlineMarket.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("items")]
    public class ItemController : ApiController
    {
        private ItemService _ItemService;

        public ItemController(ItemService itemService)
        {
            this._ItemService = itemService;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(PaginatedList<PostedAdListItem>))]
        public async Task<IHttpActionResult> Get([FromUri] PostedAdSearchFilter filter, int pageIndex = 0, int pageSize = 10)
        {
            return Ok(await _ItemService.SearchPostedAdAsync(filter, pageIndex, pageSize));
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(PostedAdDetails))]
        public async Task<IHttpActionResult> GetItemById(int id)
        {
            var item = await _ItemService.GetItemByIDAsync(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
    }
}
