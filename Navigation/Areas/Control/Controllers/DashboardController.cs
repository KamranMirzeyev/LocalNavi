using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Navigation.Helper;

namespace Navigation.Areas.Control.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Control/Dashboard
        [AuthAdmin]
        public ActionResult Index()
        {
            return View();
        }
        [AuthAdmin]
        public ActionResult Logout()
        {
            Session["admin"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}