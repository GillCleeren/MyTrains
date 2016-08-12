using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.UnitTests.Mocks;
using System.Threading.Tasks;

namespace MyTrains.Core.UnitTests.Tests.Services
{
    [TestClass]
    public class CityDataServiceTests
    {
        ICityDataService cityDataService;

        [TestInitialize]
        public void Initialize()
        {
            cityDataService = ServiceMocks.GetMockCityDataService(3);
        }

        [TestMethod]
        public async Task GetCities_Return_All_Cities()
        {
            var cities = await cityDataService.GetAllCities();

            Assert.AreEqual(3, cities.Count);
        }
    }
}