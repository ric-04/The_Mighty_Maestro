using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Models.Maestro
{
    public class MaestroCreate
    {   
        [Display(Name = "Maestro Name")]
        public string MaestroName { get; set; }
        [Display(Name = "Venue Id")]
        public int VenueId { get; set; } = 1; //<- MAESTRO will begin on level 1
        [Display(Name = "Instructor Id")]
        public int ProfessorId { get; set; } = 1;
    }
}
