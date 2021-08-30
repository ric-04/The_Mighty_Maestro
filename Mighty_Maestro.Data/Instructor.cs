using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Data
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }
        public Guid OwnerId { get; set; }

        public string Name { get; set; }

        public virtual List<Maestro> Maestros { get; set; }

        public Instructor()
        {

        }

        public Instructor(int instructorId, Guid ownerId, string name)
        {
            InstructorId = instructorId;
            Name = name;
            OwnerId = ownerId;
        }


    }
}