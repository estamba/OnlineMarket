using OnlineMarket.Repositories;
using OnlineMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineMarket.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("cities")]
    public class CityController : ApiController
    {
        private CityRepository _CityRepository;

        public CityController(CityRepository cityRepository)
        {
            this._CityRepository = cityRepository;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var cities = _CityRepository.Get(c => c.IsEnabled == true);
            return Ok(cities.Select(c => new
            {
                Id = c.ID,
                Name = c.Name,
            }));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetCityById(int id)
        {
            var city = await _CityRepository.GetByIDAsync(id);
            if (city != null)
            {
                return Ok(new
                {
                    Id = city.ID,
                    Name = city.Name
                });
            }

            return NotFound();
        }
    }

    [RoutePrefix("locations")]
    public class LocationController: ApiController
    {
        private LocationRepository _LocationRepository;

        public LocationController(LocationRepository locationRepository)
        {
            _LocationRepository = locationRepository;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_LocationRepository.GetAll().Select(l => new
            {
                Id = l.Id,
                Name = l.Name,
                CityId = l.CityId
            }));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetLocationById(int id)
        {
            var location = await _LocationRepository.GetByIDAsync(id);
            if (location != null)
            {
                return Ok(new
                {
                    Id = location.Id,
                    Name = location.Name,
                    CityId = location.CityId
                });
            }

            return NotFound();
        }
    }
}
