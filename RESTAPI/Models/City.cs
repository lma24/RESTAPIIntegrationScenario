using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace RESTAPI.Models
{
    public partial class City
    {
        public City()
        {
            CityWeathers = new HashSet<CityWeather>();
        }

        public int CityId { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string CityName { get; set; }
        public int RegionId { get; set; }
        public int CountryId { get; set; }

        [Range(1, 5, ErrorMessage = "Rating Must be between 1 to 5")]
        public int TouristRating { get; set; }
        public DateTime EstablishedDate { get; set; }
        public int EstimatedPopulation { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Country Country { get; set; }
        public virtual StateRegion Region { get; set; }
        public virtual ICollection<CityWeather> CityWeathers { get; set; }
    }
}
