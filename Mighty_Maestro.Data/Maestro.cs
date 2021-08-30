using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Data
{
    public class Maestro
    {
        [Key]
        public int MaestroId { get; set; }
        public Guid OwnerId { get; set; }
        public string MaestroName { get; set; }
        public int TotalPoints { get; set; }
        public int ScalesPoints { get; set; }
        public int ChordsPoints { get; set; }
        public int KeysPoints { get; set; }
        public int ProgressionsPoints { get; set; }
        // Can these points be set up more efficiently using an enum?
        public string VenueAchieved { get; set; }
        public string Password { get; set; }
        [ForeignKey(nameof(Venue))]
        public int VenueId { get; set; }
        public virtual Venue Venue { get; set; }
        [ForeignKey(nameof(Instructor))]
        public int ProfessorId { get; set; }
        public virtual Instructor Instructor { get; set; }

        public Maestro()
        {

        }
    }
}