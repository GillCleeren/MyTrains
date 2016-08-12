using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;

namespace MyTrains.Core.Repositories
{
    public class CityRepository: BaseRepository, ICityRepository
    {
        private static readonly List<City> AllCities = new List<City>
        {
            new City
            {
                CityId = 1,
                CityName = "London"
            },
            new City
            {
                CityId = 2,
                CityName = "Manchester"
            },
            new City
            {
                CityId = 3,
                CityName = "Liverpool"
            },
             new City
            {
                CityId = 4,
                CityName = "Cambridge"
            },

             new City
            {
                CityId = 5,
                CityName = "Glasgow"
            },

             new City
            {
                CityId = 6,
                CityName = "Aberdeen"
            },
             new City
             {
                CityId = 7,
                CityName = "Bath"
            },
             new City
             {
                CityId = 8,
                CityName = "Oxford"
            }
        };

        public async Task<List<City>> GetAllCities()
        {
            return await Task.FromResult(AllCities);
        }

        public async Task<City> GetCityById(int cityId)
        {
            return await Task.FromResult(AllCities.FirstOrDefault(c => c.CityId == cityId));
        }
    }
}
