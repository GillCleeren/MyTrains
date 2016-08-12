using System;

namespace MyTrains.Core.Model
{
    public class Journey: BaseModel
    {
        public int JourneyId { get; set; }

        public int FromCityId{ get; set; }

        public int ToCityId { get; set; }

        public City FromCity { get; set; }

        public City ToCity { get; set; }

        public DateTime JourneyDate { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public double Price { get; set; }

        public string Platform { get; set; }
    }
}