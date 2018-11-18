using OnlineMarket.Common.Models;
using OnlineMarket.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Interface.Repositories
{
    public interface ICategoryRepository
    {
        AdCategory GetCategoryById(int id);
        Task<AdCategory> GetCategoryByIdAsync(int id);
        List<AdCategory> GetAllCategories(bool? active = null);
        Task<List<AdCategory>> GetAllCategoriesAsync(bool? active = null);
    }
}
