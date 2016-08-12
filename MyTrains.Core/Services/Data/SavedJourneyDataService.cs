using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Model;

namespace MyTrains.Core.Services.Data
{
    public class SavedJourneyDataService: ISavedJourneyDataService
    {
        private readonly ISavedJourneyRepository _savedJourneyRepository;
        private readonly IJourneyDataService _journeyDataService;
        private readonly ICityDataService _cityDataService;

        public SavedJourneyDataService(ISavedJourneyRepository savedJourneyRepository, IJourneyDataService journeyDataService, ICityDataService cityDataService)
        {
            _savedJourneyRepository = savedJourneyRepository;
            _journeyDataService = journeyDataService;
            _cityDataService = cityDataService;
        }

        public async Task<IEnumerable<SavedJourney>> GetSavedJourneyForUser(int userId)
        {

            var list = await _savedJourneyRepository.GetSavedJourneyForUser(userId);
            foreach (var savedJourney in list)
            {
                var journey = await _journeyDataService.GetJourneyDetails(savedJourney.JourneyId);
                journey.FromCity = await _cityDataService.GetCityById(journey.FromCityId);
                journey.ToCity = await _cityDataService.GetCityById(journey.ToCityId);

                savedJourney.Journey = journey;
                savedJourney.JourneyId = journey.JourneyId;
            }

            return list;
        }

        public async Task AddSavedJourney(int userId, int journeyId, int numberOfTravellers)
        {
            await _savedJourneyRepository.AddSavedJourney(userId, journeyId, numberOfTravellers);
        }
    }
}