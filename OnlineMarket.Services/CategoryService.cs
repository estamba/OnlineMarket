using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.Common.Models;
using OnlineMarket.DAL;
using OnlineMarket.Repositories;

namespace OnlineMarket.Services
{
    public class CategoryService
    {
        private UnitOfWork _UnitOfWork;

        public CategoryService(UnitOfWork uow)
        {
            this._UnitOfWork = uow;
        }

        public Task<List<Category>> GetCategoriesAsync()
        {
            return Task.Run(() => _UnitOfWork.CategoryRepository.GetAll());
        }

        public Task<List<Category>> GetMainCategoriesAsync()
        {
            return Task.Run(() => _UnitOfWork.CategoryRepository.Get(c => c.ParentId.HasValue == false));
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            return _UnitOfWork.CategoryRepository.GetByIDAsync(id);
        }
    }
}
