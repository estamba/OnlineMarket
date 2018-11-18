using OnlineMarket.DAL;
using OnlineMarket.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Services
{
    public class SellerService
    {
        UnitOfWork _unitOfWork;
        public SellerService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      
    }
}
