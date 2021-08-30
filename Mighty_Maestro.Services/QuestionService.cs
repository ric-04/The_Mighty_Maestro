using Mighty_Maestro.Data;
using Mighty_Maestro.Models.Answer;
using Mighty_Maestro.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Services
{
    public class QuestionService
    {
        private readonly Guid _userId;

        public QuestionService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateQuestion(QuestionCreate model)
        {
            var entity =
                new Question()
                {   
                    OwnerId = _userId,
                  //VenueId = model.VenueId,
                    GenreType = model.GenreType,
                    QuestionQuestion = model.QuestionQuestion,
                  //CorrectChoice = model.CorrectChoice,
                    QuestionPoints = model.QuestionPoints,
                    VenueName = model.VenueName,
                  //QuestionGenre = model.QuestionGenre,
                };
            using (var ctx = new ApplicationDbContext())
            {
              //ctx.Venues.SingleOrDefault(v => v.VenueId == entity.VenueId).Questions.Add(entity);
              // Adds QUESTION TO VENUE
                ctx.Questions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<QuestionListItem> GetQuestions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Questions
                        //.Where(e => e.OwnerId == _userId) // Removing this allows all users to view/access questions.
                        .Select(
                                e =>
                                    new QuestionListItem
                                    {
                                        QuestionId = e.QuestionId,
                                        QuestionQuestion = e.QuestionQuestion,
                                        //Answer = e.Answer,
                                        //QuestionPoints = e.QuestionPoints,
                                        //QuestionGenre = e.QuestionGenre,
                                        //QuestionId = e.QuestionId
                                        VenueName = e.VenueName,
                                        GenreType = e.GenreType
                                    }
                        );
                return query.ToArray();
            }
        }
        public QuestionDetail GetQuestionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Questions
                        .Single(e => e.QuestionId == id && e.OwnerId == _userId);
                return
                    new QuestionDetail
                    {
                        QuestionId = entity.QuestionId,
                        QuestionQuestion = entity.QuestionQuestion,    
                        //CorrectChoice = entity.CorrectChoice,
                        //ChoiceOne = entity.ChoiceOne,
                        //ChoiceTwo = entity.ChoiceTwo,
                        //ChoiceThree = entity.ChoiceThree,
                        QuestionPoints = entity.QuestionPoints,
                        GenreType = entity.GenreType,
                        VenueName = entity.VenueName
                    };
            }
        }

        public AnswerQuestion GetAnswerQuestionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Questions
                        .Single(e => e.QuestionId == id); // && e.OwnerId == _userId) <- Take out so student can answer question
                return
                    new AnswerQuestion
                    {
                        QuestionId = entity.QuestionId,
                        Question = entity.QuestionQuestion,
                        Answer = null
                    };
            }
        }

        public bool UpdateQuestion(QuestionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Questions
                        .Single(e => e.QuestionId == model.QuestionId && e.OwnerId == _userId);

                entity.QuestionId = model.QuestionId;
                entity.QuestionQuestion = model.QuestionQuestion;
                //entity.CorrectChoice = model.CorrectChoice;
                //entity.ChoiceOne = model.ChoiceOne;
                //entity.ChoiceTwo = model.ChoiceTwo;
                //entity.ChoiceThree = model.ChoiceThree;
                entity.QuestionPoints = model.QuestionPoints;
                //entity.QuestionGenre = model.QuestionGenre;
                entity.VenueName = model.VenueName;
                entity.GenreType = model.GenreType;
                

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteQuestion(int questionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Questions
                        .Single(e => e.QuestionId == questionId && e.OwnerId == _userId);

                ctx.Questions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}