using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrains.Core.Model;

namespace MyTrains.Core.Contracts.Repository
{
    public  interface IJourneyRepository
    {
        Task<IEnumerable<Journey>> SearchJourney(int fromCity, int toCity, DateTime journeyDate, DateTime departureTime);

        Task<Journey> GetJourneyDetails(int journeyId);
    }
}
