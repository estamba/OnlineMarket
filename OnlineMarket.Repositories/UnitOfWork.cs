using OnlineMarket.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Repositories
{
    public class UnitOfWork
    {
        private OnlineMarketEntities _Context;
        private ItemRepository _ItemRepository;
        private DocumentRepository _DocumentRepository;
        private LocationRepository _LocationRepository;
        private CategoryRepository _CategoryRepository;
        private SellerRepository _SellerRepository;
        private CityRepository _CityRepository;
        private AccountRepository _accountRepository;

        public UnitOfWork(OnlineMarketEntities context)
        {
            this._Context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _Context.SaveChangesAsync();
        }
        public void LogQueries()
        {
            _Context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public  void SaveChanges()
        {
             _Context.SaveChanges();
        }
        public ItemRepository ItemRepository
        {
            get
            {
                if (_ItemRepository == null)
                {
                    _ItemRepository = new ItemRepository(_Context);
                }
                return _ItemRepository;
            }
        }

        public DocumentRepository DocumentRepository
        {
            get
            {
                if (_DocumentRepository == null)
                {
                    _DocumentRepository = new DocumentRepository(_Context);
                }
                return _DocumentRepository;
            }
        }

        public LocationRepository LocationRepository
        {
            get
            {
                if (_LocationRepository == null)
                {
                    _LocationRepository = new LocationRepository(_Context);
                }
                return _LocationRepository;
            }
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                if (_CategoryRepository == null)
                {
                    _CategoryRepository = new CategoryRepository(_Context);
                }
                return _CategoryRepository;
            }
        }

        public SellerRepository SellerRepository
        {
            get
            {
                if (_SellerRepository == null)
                {
                    _SellerRepository = new SellerRepository(_Context);
                }
                return _SellerRepository;
            }
        }


        public CityRepository CityRepository
        {
            get
            {
                if (_CityRepository == null)
                {
                    _CityRepository = new CityRepository(_Context);
                }
                return _CityRepository;
            }
        }

        public AccountRepository accountRepository
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_Context);
                }
                return _accountRepository;
            }
        }

    }
}
