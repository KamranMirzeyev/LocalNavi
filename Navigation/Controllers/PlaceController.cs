using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Navigation.Controllers
{
    public class PlaceController : Controller
    {
        // GET: Place
        [HttpGet]
        public ActionResult AddListing()
        {
            return View();
        }


    }
}