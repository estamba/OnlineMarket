using OnlineMarket.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Repositories
{
    public class AccountRepository : GenericRepository<AspNetUser>
    {
        OnlineMarketEntities onlineMarketEntities;

        public AccountRepository(OnlineMarketEntities onlineMarketEntities):base(onlineMarketEntities)
        {
            this.onlineMarketEntities = onlineMarketEntities;
        }
       
    }
}
