﻿using System;
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
        NaviContext db = new NaviContext();
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.category = db.Categories.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Listing()
        {
            return View();
        }

        [Auth]
        public ActionResult AddListing()
        {
            return View();
        }

        [Auth]
        public ActionResult Profile()
        {
            return View();
        }

    }
}