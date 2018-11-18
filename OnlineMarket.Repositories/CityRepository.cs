using OnlineMarket.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnlineMarket.Repositories
{
    public class CityRepository : GenericRepository<City>
    {

        public CityRepository(DbContext context) : base(context)
        {
        }
    }
}
