using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Models.Answer
{
    public class AnswerDetail
    {
        public int AnswerId { get; set; }
        public int MaestroId { get; set; }
        public string AnswerQuestion { get; set; }
        public int QuestionId { get; set; }
    }
}
