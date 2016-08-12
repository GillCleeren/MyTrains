using System;

namespace MyTrains.Core.Model.App
{
    public class SearchParameters
    {
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public DateTime JourneyDate { get; set; }
        public string DepartureTime { get; set; }
    }
}