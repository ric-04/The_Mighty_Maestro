using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Models.Feedback
{
    public class FeedbackListItem
    {
        public int FeedbackId { get; set; }
        public int TeacherId { get; set; }
        public int AnswerId { get; set; }
        public bool CorrectAnswer { get; set; }
        public string FeedbackAnswer { get; set; }

    }
}
