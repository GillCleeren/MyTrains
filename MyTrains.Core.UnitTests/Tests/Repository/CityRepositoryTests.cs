using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.UnitTests.Mocks;
using System.Threading.Tasks;

namespace MyTrains.Core.UnitTests.Tests.Repository
{
    [TestClass]
    public class CityRepositoryTests
    {
        ICityRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = RepositoryMocks.GetMockCityRepository(3).Object;
        }

        [TestMethod]
        public async Task GetCities_Return_All_Cities()
        {
            var cities = await repository.GetAllCities();

            Assert.AreEqual(3, cities.Count);
        }
    }
}