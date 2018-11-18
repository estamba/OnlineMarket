using OnlineMarket.DAL;
using OnlineMarket.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Services
{
    public class MetadataService
    {
        private UnitOfWork _UnitOfWork;

        public MetadataService(UnitOfWork uow)
        {
            this._UnitOfWork = uow;
        }

        public Task<List<City>> GetCitiesAync()
        {
            return Task.Run(() => _UnitOfWork.CityRepository.GetAll());
        }

        public Task<List<Location>> GetLocationsAsync()
        {
            return Task.Run(() => _UnitOfWork.LocationRepository.GetAll());
        }
    }
}
