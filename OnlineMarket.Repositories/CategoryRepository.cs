using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.Common.Models;
using OnlineMarket.DAL;
using System.Data.Entity;

namespace OnlineMarket.Repositories
{
    public class CategoryRepository: GenericRepository<Category>
    {
        OnlineMarketEntities context;
        public CategoryRepository(OnlineMarketEntities context): base(context)
        {
            this.context = context;
        }
        public List<Category> AccessSomething()
        {
           return context.Categories.ToList();

        }
    }
}
