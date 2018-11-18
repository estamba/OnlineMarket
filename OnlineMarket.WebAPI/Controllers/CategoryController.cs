using OnlineMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineMarket.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("categories")]
    public class CategoryController : ApiController
    {
        private CategoryService _CategoryService;

        public CategoryController(CategoryService categoryService)
        {
            this._CategoryService = categoryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var categoryList = await _CategoryService.GetCategoriesAsync();
            return Ok(categoryList.Select(c => new
            {
                Id = c.Id,
                Name = c.Name,
                ParentId = c.ParentId
            }));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var category = await _CategoryService.GetCategoryByIdAsync(id);
            if (category != null)
            {
                return Ok(new
                {
                    Id = category.Id,
                    Name = category.Name,
                    ParentId = category.ParentId
                });
            }

            return NotFound();
        }
    }
}
