using System.Collections.Generic;
using Moq;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;
using MyTrains.Core.Services.Data;

namespace MyTrains.Core.UnitTests.Mocks
{
    public class ServiceMocks
    {
        public static CityDataService GetMockCityDataService(int count)
        {
            var list = new List<City>();

            var mockexpenseRepository = new Mock<ICityRepository>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new City { CityId = count });
            }
            mockexpenseRepository.Setup(m => m.GetAllCities()).ReturnsAsync(list);

            var cityDataService = new CityDataService(mockexpenseRepository.Object);
            return cityDataService;
        }
    }
}