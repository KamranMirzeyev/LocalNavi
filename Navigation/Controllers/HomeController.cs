using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Navigation.DAL;
using Navigation.Helper;
using Navigation.Models;

namespace Navigation.Controllers
{
    public class HomeController : Controller
    {
       private  readonly NaviContext db = new NaviContext();
        public ActionResult Index()
        {
           HomeViewModel model = new HomeViewModel();
            model.category = db.Categories.ToList();
            return View(model);
        }

        //categoriya yazanda cixmasi
        [HttpPost]
        public JsonResult GetCategories(string Prefix)
        {

            var category = (from c in db.Categories
                where c.Name.StartsWith(Prefix)
                select new { c.Name, c.Id });
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        //seherlerin yazanda cixmasi
        [HttpPost]
        public JsonResult GetCities(string Prefix)
        {
            var category = (from c in db.Cities
                where c.Name.StartsWith(Prefix)
                select new { c.Name, c.Id });
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        //about index
        public ActionResult About()
        {
           

            return View();
        }

        //contact index
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }




        public ActionResult Logout()
        {
            Session["Login"] = null;
            return RedirectToAction("Index", "Home");
        }       

    }
}