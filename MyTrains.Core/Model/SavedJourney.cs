namespace MyTrains.Core.Model
{
    public class SavedJourney: BaseModel
    {
        public int JourneyId { get; set; }

        public Journey Journey { get; set; }

        public int UserId { get; set; }

        public int NumberOfTravellers { get; set; }

    }
}