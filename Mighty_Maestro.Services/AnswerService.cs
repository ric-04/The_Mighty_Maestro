using Mighty_Maestro.Data;
using Mighty_Maestro.Models.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Services
{
    public class AnswerService
    {
        private readonly Guid _userId;

        public AnswerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAnswer(AnswerCreate model)
        {
            var entity =
                new Answer()
                {
                    OwnerId = _userId,
                  //AnswerId = model.AnswerId,
                    MaestroId = model.MaestroId,
                    AnswerQuestion = model.AnswerQuestion,
                    QuestionId = model.QuestionId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Answers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AnswerListItem> GetAnswers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Answers
                      //.Where(e => e.OwnerId == userId)
                        .Select(
                                e =>
                                    new AnswerListItem
                                    {
                                        MaestroId = e.MaestroId,
                                        AnswerQuestion = e.AnswerQuestion,
                                        AnswerId = e.AnswerId // !!!
                                    }
                                );
                return query.ToArray();
            }
        }

        public AnswerDetail GetAnswerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Answers
                        .Single(e => e.AnswerId == id && e.OwnerId == _userId);
                return
                    new AnswerDetail
                    {
                        AnswerId = entity.AnswerId,
                        MaestroId = entity.MaestroId,
                        AnswerQuestion = entity.AnswerQuestion,
                        QuestionId = entity.QuestionId
                    };
            }
        }
    }
}