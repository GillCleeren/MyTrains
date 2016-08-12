using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Contracts.Services;
using MyTrains.Core.Model;

namespace MyTrains.Core.Services.Data
{
    public class JourneyDataService: IJourneyDataService
    {
        private readonly IJourneyRepository _journeyRepository;
        private readonly ICityRepository _cityRepository;


        public JourneyDataService(IJourneyRepository journeyRepository, 
            ICityRepository cityRepository)
        {
            _journeyRepository = journeyRepository;
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<Journey>> SearchJourney(int fromCity, int toCity, DateTime journeyDate, DateTime departureTime)
        {
            var journeys = await _journeyRepository.SearchJourney(fromCity, toCity, journeyDate, departureTime);
            foreach (var journey in journeys)
            {
                journey.FromCity =  await _cityRepository.GetCityById(journey.FromCityId);
                journey.ToCity = await _cityRepository.GetCityById(journey.ToCityId);
            }
            return journeys;
        }

        public async Task<Journey> GetJourneyDetails(int journeyId)
        {
            return await _journeyRepository.GetJourneyDetails(journeyId);
        }
    }
}