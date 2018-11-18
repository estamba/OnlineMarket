using OnlineMarket.Common.Models;
using OnlineMarket.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Interface.Services
{
    public interface ICategoryService
    {
        AdCategory GetCategoryById(int id);
        Task<AdCategory> GetCategoryByIdAsync(int id);
        List<AdCategory> GetAllCategories();
        Task<List<AdCategory>> GetActiveCategoriesAsync();
    }
}
