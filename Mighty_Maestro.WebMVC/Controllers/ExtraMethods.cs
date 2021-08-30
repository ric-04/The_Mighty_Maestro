using Mighty_Maestro.Models.Venue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mighty_Maestro.WebMVC.Controllers
{
    public class ExtraMethods
    {
        //GET
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(VenueCreate model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    var service = CreateVenueService();

        //    if (service.CreateVenue(model))
        //    {
        //        TempData["saveresult"] = "venue created!";
        //        return RedirectToAction("index");
        //    };

        //    ModelState.AddModelError("", "sorry, your venue could not be created.");

        //    return View(model);
        //}

        //public ActionResult Edit(int id)
        //{
        //    var service = CreateVenueService();
        //    var detail = service.GetVenueById(id);
        //    var model =
        //        new VenueEdit
        //        {
        //            VenueId = detail.VenueId,
        //            Name = detail.Name,
        //            PointsRequired = detail.PointsRequired
        //        };
        //    return View(model);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, VenueEdit model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    if (model.VenueId != id)
        //    {
        //        ModelState.AddModelError("", "Id Mismatch");
        //        return View(model);
        //    }
        //    var service = CreateVenueService();

        //    if (service.UpdateVenue(model))
        //    {
        //        TempData["SaveResult"] = "Venue updated!";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Sorry, your Venue could not be updated.");
        //    return View(model);
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //public ActionResult Details(int id)
        //{
        //    var svc = CreateVenueService();
        //    var model = svc.GetVenueById(id);

        //    return View(model);
        //}

        //[ActionName("Delete")]
        //public ActionResult Delete(int id)
        //{
        //    var svc = CreateVenueService();
        //    var model = svc.GetVenueById(id);

        //    return View(model);
        //}
        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeletePost(int id)
        //{
        //    var service = CreateVenueService();
        //    service.DeleteVenue(id);
        //    TempData["SaveResult"] = "Venue Deleted.";
        //    return RedirectToAction("Index");
        //}

        //private VenueService CreateVenueService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new VenueService(userId);
        //    return service;
        //}

        //public bool CreateVenue(VenueCreate model)
        //{
        //    var entity =
        //        new Venue()
        //        {
        //            OwnerId = _userId,
        //            Name = model.Name,
        //            PointsRequired = model.PointsRequired,
        //        };
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        ctx.Venues.Add(entity);
        //        return ctx.SaveChanges() == 1;
        //    }
        //}

    //    public bool UpdateVenue(VenueEdit model)
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var entity =
    //                ctx
    //                    .Venues
    //                    .Single(e => e.VenueId == model.VenueId && e.OwnerId == _userId);

    //            entity.Name = model.Name;
    //            entity.PointsRequired = model.PointsRequired;
    //            entity.VenueId = model.VenueId;

    //            return ctx.SaveChanges() == 1;
    //        }
    //    }

    //    public bool DeleteVenue(int venueId)
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var entity =
    //                ctx
    //                    .Venues
    //                    .Single(e => e.VenueId == venueId && e.OwnerId == _userId);

    //            ctx.Venues.Remove(entity);

    //            return ctx.SaveChanges() == 1;
    //        }
    //    }
    }
}