using Microsoft.AspNet.Identity;
using Mighty_Maestro.Models.Answer;
using Mighty_Maestro.Models.Feedback;
using Mighty_Maestro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mighty_Maestro.WebMVC.Controllers
{
    [Authorize(Roles = "Instructor, Admin")]
    public class FeedbackController : Controller
    {
        private FeedbackService CreateFeedbackService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FeedbackService(userId);
            return service;
        }

        // GET: Feedback
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FeedbackService(userId);
            var model = service.GetFeedbacks();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.FeedbackSelectionList = new FeedbackService(Guid.Parse(User.Identity.GetUserId())).GetFeedbacks();

            return View();
        }

        //GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedbackCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFeedbackService();

            if (service.CreateFeedback(model))
            {
                TempData["SaveResult"] = "Feedback Submitted!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Sorry, your feedback could not be given.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateFeedbackService();
            var model = svc.GetFeedbackById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFeedbackService();
            var detail = service.GetFeedbackById(id);
            var model =
                new FeedbackEdit
                {
                    FeedbackId = detail.FeedbackId,
                    TeacherId = detail.TeacherId,
                    AnswerId = detail.AnswerId,
                    CorrectAnswer = detail.CorrectAnswer,
                    FeedbackAnswer = detail.FeedbackAnswer,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FeedbackEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FeedbackId!= id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateFeedbackService();

            if (service.UpdateFeedback(model))
            {
                TempData["SaveResult"] = "Feedback Updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sorry, your feedback could not be updated.");
            return View(model);
        }
        
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFeedbackService();
            var model = svc.GetFeedbackById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFeedbackService();
            service.DeleteFeedback(id);
            TempData["SaveResult"] = "Feedback Deleted.";
            return RedirectToAction("Index");
        }
    }
}