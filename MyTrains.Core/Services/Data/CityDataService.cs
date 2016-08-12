using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Model;

namespace MyTrains.Core.Services.Data
{
    public class CityDataService: ICityDataService
    {
        private readonly ICityRepository _cityRepository;
        public CityDataService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public virtual async Task<List<City>> GetAllCities()
        {
            return await _cityRepository.GetAllCities();
        }

        public async Task<City> GetCityById(int cityId)
        {
            return await _cityRepository.GetCityById(cityId);
        }
    }
}