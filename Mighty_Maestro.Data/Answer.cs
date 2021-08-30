using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Data
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public Guid OwnerId { get; set; }
        [ForeignKey(nameof(Maestro))]
        public int MaestroId { get; set; } // Navigational Property
        public virtual Maestro Maestro { get; set; }
        public string AnswerQuestion { get; set; }

        [ForeignKey(nameof(Question))]
        public int QuestionId { get; set; } // Navigational Property
        public virtual Question Question { get; set; }

        public Answer()
        {

        }
    }
}