using System;
using System.Collections.Generic;

#nullable disable

namespace RESTAPI.Models
{
    public partial class StateRegion
    {
        public StateRegion()
        {
            Cities = new HashSet<City>();
        }

        public int RegionId { get; set; }
        public string StateRegion1 { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
