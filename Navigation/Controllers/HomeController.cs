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

        public ActionResult About()
        {
           

            return View();
        }

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