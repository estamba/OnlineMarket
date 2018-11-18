using OnlineMarket.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnlineMarket.Repositories
{
    public class SellerRepository : GenericRepository<Seller>
    {
        public SellerRepository(DbContext context) : base(context){}
        public Seller GetSellerByUserName(string username)
        {
            var seller = Get(x => x.AspNetUser.UserName == username).Select(x => x).FirstOrDefault();
            return seller;
        }

        public Task<Seller> GetSellerByAccountIdAsync(string accountId)
        {
            return Task.Run(() => Get(s => s.AccountId == accountId).FirstOrDefault());
        }
    }
}
