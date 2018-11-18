using OnlineMarket.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Interface.Repositories
{
    public interface IMetadataRepository
    {
        List<Location> GetLocations();
        Task<List<Location>> GetLocationsAsync();

        List<City> GetCities();
        Task<List<City>> GetCitiesAync();
    }
}
