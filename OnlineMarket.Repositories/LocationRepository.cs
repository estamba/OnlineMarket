using OnlineMarket.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Repositories
{
    public class LocationRepository: GenericRepository<Location>
    {
        public LocationRepository(DbContext context): base(context)
        {
            
        }
    }
}
