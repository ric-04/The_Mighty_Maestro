using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mighty_Maestro.Data;

namespace Mighty_Maestro.Models.Venue
{
    public class VenueDetail
    {
        [Display(Name = "Venue Id")]
        public int VenueId {get; set; }
        public int Stage { get; set; }
        [Display(Name = "Venue Name")]
        public string Name { get; set; }
        [Display(Name = "Points Required")]
        public int PointsRequired { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        // public string MembersAccessed {get; set;}
    }
}