using OnlineMarket.Common.Models;
using OnlineMarket.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Interface.Repositories
{
    public interface IItemRepository
    {
        Task SaveItemAsync(Item item);
    }
}
