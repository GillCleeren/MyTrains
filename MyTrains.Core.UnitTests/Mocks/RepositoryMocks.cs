using System.Collections.Generic;
using Moq;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;

namespace MyTrains.Core.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<ICityRepository> GetMockCityRepository(int count)
        {
            var list = new List<City>();
            var mockCityRepository = new Mock<ICityRepository>();

            for (int i = 0; i < count; i++)
            {
                list.Add(new City { CityId = count });
            }

            mockCityRepository.Setup(m => m.GetAllCities()).ReturnsAsync(list);
            mockCityRepository.Setup(m => m.GetCityById(It.IsAny<int>())).ReturnsAsync(list[0]);
            return mockCityRepository;
        }
    }
}