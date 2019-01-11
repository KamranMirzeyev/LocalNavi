using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Navigation.Helper;

namespace Navigation.Areas.Control.Controllers
{
    [AuthAdmin]
    public class DashboardController : Controller
    {
        // GET: Control/Dashboard
      
        public ActionResult Index()
        {
            return View();
        }

        //logout
       
        public ActionResult Logout()
        {
            Session["admin"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}