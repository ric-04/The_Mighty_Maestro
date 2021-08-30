using Microsoft.AspNet.Identity;
using Mighty_Maestro.Models.Questions;
using Mighty_Maestro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mighty_Maestro.WebMVC.Controllers
{
    [Authorize(Roles = "Instructor, Admin")]
    public class QuestionController : Controller
    {
        private QuestionService CreateQuestionService() // This is the "instance" of the service
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new QuestionService(userId);
            return service;
        }

        // GET: Question
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new QuestionService(userId);
            var model = service.GetQuestions();

            return View(model);
        }
        
        public ActionResult Create()
        {
            ViewBag.VenueSelectionList = new VenueService(Guid.Parse(User.Identity.GetUserId())).GetVenues();

            return View();
        }
        
        // GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateQuestionService();

            if (service.CreateQuestion(model))
            {
                TempData["SaveResult"] = "Question Created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Sorry, your question could not be created.");

            return View(model);
        }
        
        public ActionResult Details(int id)
        {
            var svc = CreateQuestionService();
            var model = svc.GetQuestionById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateQuestionService();
            var detail = service.GetQuestionById(id);
            var model =
                new QuestionEdit
                {
                    QuestionId = detail.QuestionId,
                    QuestionQuestion = detail.QuestionQuestion,
                    //CorrectChoice = detail.CorrectChoice,
                    //ChoiceOne = detail.ChoiceOne,
                    //ChoiceTwo = detail.ChoiceTwo,
                    //ChoiceThree = detail.ChoiceThree,
                    QuestionPoints = detail.QuestionPoints,
                    VenueName = detail.VenueName,
                    GenreType = detail.GenreType,
                    //QuestionGenre = detail.QuestionGenre

                };
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, QuestionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.QuestionId!= id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateQuestionService();

            if (service.UpdateQuestion(model))
            {
                TempData["SaveResult"] = "Question Updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sorry, your question could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        
        public ActionResult Delete(int id)
        {
            var svc = CreateQuestionService();
            var model = svc.GetQuestionById(id);

            return View(model);
        }
        
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateQuestionService();
            service.DeleteQuestion(id);
            TempData["SaveResult"] = "Question Deleted.";
            return RedirectToAction("Index");
        }

    }
}