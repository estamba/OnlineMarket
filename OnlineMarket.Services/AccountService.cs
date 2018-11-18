using OnlineMarket.Common;
using OnlineMarket.Common.Models;
using OnlineMarket.DAL;
using OnlineMarket.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Services
{
    public class AccountService
    {
        private UnitOfWork _unitOfWork;

        public AccountService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
