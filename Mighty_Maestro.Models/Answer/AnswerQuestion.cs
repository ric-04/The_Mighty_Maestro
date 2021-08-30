using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Models.Answer
{
    public class AnswerQuestion
    {
        public int QuestionId { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public int MaestroId { get; set; }
    }
}
