using Microsoft.AspNet.Identity;
using Mighty_Maestro.Models.Answer;
using Mighty_Maestro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mighty_Maestro.WebMVC.Controllers
{
    [Authorize(Roles = "Student, Admin")]
    public class AnswerController : Controller
    {
        // GET: Answer
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AnswerService(userId);
            var model = service.GetAnswers();

            return View(model);
        }

        // Study This!
        public ActionResult Create(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            QuestionService service = new QuestionService(userId);

            AnswerQuestion model = service.GetAnswerQuestionById(id);
          //ViewBag.AnswerSelectionList = new AnswerService(Guid.Parse(User.Identity.GetUserId())).GetAnswers();

            return View(model);
        }

        // GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnswerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAnswerService();

            if (service.CreateAnswer(model))
            {
                TempData["SaveResult"] = "Answer Submitted.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Sorry, your answer could not be submitted.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAnswerService();
            var model = svc.GetAnswerById(id);

            return View(model);
        }

        private AnswerService CreateAnswerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AnswerService(userId);
            return service;
        }
    }
}