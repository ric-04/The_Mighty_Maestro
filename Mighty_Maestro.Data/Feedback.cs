using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Data
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public Guid OwnerId {get; set;}
        [ForeignKey(nameof(Instructor))]
        public int TeacherId {get; set;}
        public virtual Instructor Instructor { get; set; }
        [ForeignKey(nameof(Answer))]
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
        public bool CorrectAnswer { get; set; }
        public string FeedbackAnswer { get; set; }

        public Feedback()
        {

        }
    }
}