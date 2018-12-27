using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Navigation.DAL;
using Navigation.Models;

namespace Navigation.Controllers
{
    public class PlaceController : Controller
    {
        private readonly NaviContext db = new NaviContext();
        // GET: Place
        [HttpGet]
        public ActionResult AddListing()
        {
            PlaceViewModel model = new PlaceViewModel();
            model.category = db.Categories.ToList();
            model.city = db.Cities.ToList();
            model.Listing = db.Listings.FirstOrDefault();
            return View(model);
        }



        [HttpGet]
        public JsonResult CategoryService(int id)
        {

          var model = db.CategoryServices.Where(x => x.CategoryId == id).Select(x=> new
          {
              ServiceId = x.ServiceId,
              Name=x.Service.Name
           
          }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);

        }

    }
}