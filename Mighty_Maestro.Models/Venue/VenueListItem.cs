using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Models.Venue
{
    public class VenueListItem
    {
        [Display(Name = "Venue Name")]
        public string Name { get; set; }
        // public int PointsRequired { get; set; }
        // public string MembersAccessed {get; set;}
        [Display(Name = "Venue Id")]
        public int VenueId { get; set; }
    }
}
