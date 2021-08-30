using Mighty_Maestro.Data;
using Mighty_Maestro.Models.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Services
{
    public class FeedbackService
    {
        private readonly Guid _userId;

        public FeedbackService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateFeedback(FeedbackCreate model)
        {
            var entity =
                new Feedback()
                {
                    OwnerId = _userId,
                    FeedbackId = model.FeedbackId,
                    TeacherId = model.TeacherId,
                    AnswerId = model.AnswerId,
                    CorrectAnswer = model.CorrectAnswer,
                    FeedbackAnswer = model.FeedbackAnswer,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Feedbacks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<FeedbackListItem> GetFeedbacks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Feedbacks
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                                e =>
                                    new FeedbackListItem
                                    {
                                        FeedbackId = e.FeedbackId,
                                        TeacherId = e.TeacherId,
                                        AnswerId = e.AnswerId,
                                        CorrectAnswer = e.CorrectAnswer,
                                        FeedbackAnswer = e.FeedbackAnswer
                                    }
                    );
                return query.ToArray();
            }
        }
        public FeedbackDetail GetFeedbackById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Feedbacks
                        .Single(e => e.FeedbackId == id && e.OwnerId == _userId);
                return
                    new FeedbackDetail
                    {
                        FeedbackId = entity.FeedbackId,
                        TeacherId = entity.TeacherId,
                        AnswerId = entity.AnswerId,
                        CorrectAnswer = entity.CorrectAnswer,
                        FeedbackAnswer = entity.FeedbackAnswer,
                    };
            }
        }
        public bool UpdateFeedback(FeedbackEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Feedbacks
                        .Single(e => e.FeedbackId == model.FeedbackId && e.OwnerId == _userId);

                entity.FeedbackId = model.FeedbackId;
                entity.TeacherId = model.TeacherId;
                entity.AnswerId = model.AnswerId;
                entity.CorrectAnswer = model.CorrectAnswer;
                entity.FeedbackAnswer = model.FeedbackAnswer;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteFeedback(int feedbackId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Feedbacks
                        .Single(e => e.FeedbackId == feedbackId && e.OwnerId == _userId);

                ctx.Feedbacks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}