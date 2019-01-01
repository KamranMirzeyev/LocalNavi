using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Navigation.Controllers
{
    public class SearchPlaceController : Controller
    {
        // GET: SearchPlace
        [HttpGet]
        public ActionResult Places()
        {
            return View();
        }
    }
}