using Microsoft.AspNet.Identity;
using Mighty_Maestro.Models.Maestro;
using Mighty_Maestro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mighty_Maestro.WebMVC.Controllers
{
    [Authorize] // This means views are only accessible to logged in users
    public class MaestroController : Controller
    {
        [Authorize(Roles = "Instructor, Admin")]
        // GET: Maestro
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaestroService(userId);
            var model = service.GetMaestros();

            return View(model);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        // GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaestroCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMaestroService();

            if (service.CreateMaestro(model))
            {
                TempData["SaveResult"] = "Maestro created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Sorry, your Maestro could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateMaestroService();
            var model = svc.GetMaestroById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMaestroService();
            var detail = service.GetMaestroById(id);
            var model =
                new MaestroEdit
                {
                    MaestroId = detail.MaestroId,
                    MaestroName = detail.MaestroName,
                    //Password = detail.Password
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, MaestroEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MaestroId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateMaestroService();

            if (service.UpdateMaestro(model))
            {
                TempData["SaveResult"] = "Maestro updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sorry, your Maestro could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMaestroService();
            var model = svc.GetMaestroById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMaestroService();
            service.DeleteMaestro(id);
            TempData["SaveResult"] = "Maestro Deleted.";
            return RedirectToAction("Index");
        }

        private MaestroService CreateMaestroService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaestroService(userId);
            return service;
        }
    }
}