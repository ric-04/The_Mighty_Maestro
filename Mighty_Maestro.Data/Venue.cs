using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Data
{
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }
        public Guid OwnerId { get; set; }
        public int Stage { get; set; }
        [Display(Name = "Venue Achieved")]
        public string Name { get; set; }
        public int PointsRequired { get; set; }
        // Many Players, to one VENUE
        public virtual List<Maestro> Maestros { get; set; } = new List<Maestro>();
        public virtual List<Question> Questions { get; set; } = new List<Question>();


        public Venue()
        {

        }

        public Venue(int venueId, string name, int stage, int pointsRequired, Guid ownerId)
        {
            VenueId = venueId;
            Name = name;
            Stage = stage;
            PointsRequired = pointsRequired;
            OwnerId = ownerId;
        }

        public Venue(int venueId, Guid ownerId, string name, int pointsRequired, List<Maestro> maestros, List<Question> questions)
        {
            VenueId = venueId;
            OwnerId = ownerId;
            Name = name;
            PointsRequired = pointsRequired;
            Maestros = maestros;
            Questions = questions;
        }
    }
}