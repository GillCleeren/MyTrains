using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyTrains.Core.Model;

namespace MyTrains.Core.Contracts.Services
{
    public interface ISavedJourneyDataService
    {
        Task<IEnumerable<SavedJourney>> GetSavedJourneyForUser(int userId);

        Task AddSavedJourney(int userId, int journeyId, int numberOfTravellers);
    }
}