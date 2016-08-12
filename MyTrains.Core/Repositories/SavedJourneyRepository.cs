using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTrains.Core.Contracts.Repository;
using MyTrains.Core.Model;

namespace MyTrains.Core.Repositories
{
    public class SavedJourneyRepository : BaseRepository  , ISavedJourneyRepository
    {

        private static readonly List<SavedJourney> AllSavedJourneys = new List<SavedJourney>
        {
            new SavedJourney {JourneyId = 1, NumberOfTravellers = 3, UserId = 1},
            new SavedJourney {JourneyId = 2, NumberOfTravellers = 2, UserId = 1},
            new SavedJourney {JourneyId = 3, NumberOfTravellers = 3, UserId = 1},
            new SavedJourney {JourneyId = 4, NumberOfTravellers = 2, UserId = 1},
            new SavedJourney {JourneyId = 1, NumberOfTravellers = 3, UserId = 2},
            new SavedJourney {JourneyId = 2, NumberOfTravellers = 3, UserId = 2}
        };

        public async Task<IEnumerable<SavedJourney>> GetSavedJourneyForUser(int userId)
        {
            return await Task.FromResult(AllSavedJourneys.Where(j => j.UserId == userId));
        }

        public async Task AddSavedJourney(int userId, int journeyId, int numberOfTravellers)
        {
            await
                Task.Run(
                    () =>
                        AllSavedJourneys.Add(new SavedJourney
                        {
                            JourneyId = journeyId,
                            NumberOfTravellers = numberOfTravellers,
                            UserId = userId
                        }));
        }

    }
}