using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Models.Maestro
{
    public class MaestroDetail
    {
        public Guid OwnerId { get; set; }
        public int MaestroId { get; set; }
        public string MaestroName { get; set; }
        public int TotalPoints { get; set; }
        public int ScalesPoints { get; set; }
        public int ChordsPoints { get; set; }
        public int KeysPoints { get; set; }
        public int ProgressionsPoints { get; set; }
        public string VenueAchieved { get; set; }
    }
}