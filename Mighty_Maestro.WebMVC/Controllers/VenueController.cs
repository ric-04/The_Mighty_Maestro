using Microsoft.AspNet.Identity;
using Mighty_Maestro.Models;
using Mighty_Maestro.Models.Venue;
using Mighty_Maestro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mighty_Maestro.WebMVC.Controllers
{
    [Authorize(Roles = "Instructor, Admin")]

    public class VenueController : Controller
    {
        // GET: Venue
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId()); // <-> Line 41 in VenueService.cs
            var service = new VenueService(userId);
            var model = service.GetVenues();

            return View(model);
        }

        public ActionResult Details(int id)
        {
         // var service = new VenueService(userId); = Same as line 29
         // var svc = CreateVenueService();
         // var model = svc.GetVenueById(id);
         // 32 = 29 & 30 Combined
            var model = CreateVenueService().GetVenueById(id);

            return View(model);
         // return View(CreateVenueService().GetVenueById(id)); =
         // 35 = 32 & 34 Combined 
        }

        private VenueService CreateVenueService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VenueService(userId);

            return service;
        }

        //public ActionResult VenueSelectionIndex()
        //{
        //    VenueNameModel model = new VenueNameModel();
        //    model.VenueList.Add(new SelectListItem { Text = "Grandparents' Garage", Value = "3" });
        //    model.VenueList.Add(new SelectListItem { Text = "School Dance", Value = "4" });
        //    model.VenueList.Add(new SelectListItem { Text = "County Fair", Value = "5" });
        //    model.VenueList.Add(new SelectListItem { Text = "Local News", Value = "6" });
        //    model.VenueList.Add(new SelectListItem { Text = "On Tour", Value = "7" });

        //    return View(model);
        //}
    }
}