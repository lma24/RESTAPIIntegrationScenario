using System;
using System.Collections.Generic;

#nullable disable

namespace RESTAPI.Models
{
    public partial class CityWeather
    {
        public int TempId { get; set; }
        public int CityId { get; set; }
        public decimal Temperature { get; set; }
        public int Humidity { get; set; }
        public DateTime EffectiveDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual City City { get; set; }
    }
}
