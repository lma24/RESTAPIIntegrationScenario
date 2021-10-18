using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.ViewModel
{
    public class CityViewModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? TouristRating { get; set; }
        public DateTime? DateEstablished { get; set; }

        public int EstimatedPopulation { get; set; }
        public string TwoDigitCountryCode { get; set; }
        public string ThreeDigitCountryCode { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Weather { get; set; }
    }
}
