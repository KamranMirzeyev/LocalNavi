using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Navigation.DAL;
using Navigation.Models;

namespace Navigation.Controllers
{
    public class SearchPlaceController : Controller
    {
        private readonly NaviContext db = new NaviContext();
        // GET: SearchPlace
        [HttpPost]
        public JsonResult Places(string categoryKey, string cityKey)
        {
            if (string.IsNullOrEmpty(categoryKey) && string.IsNullOrEmpty(cityKey))
            {
                return Json(new { status = 404, message = "Boş axtarış vermə!" }, JsonRequestBehavior.AllowGet);
            }
            
           List<searchPlace> modal = new List<searchPlace>();
            if (!string.IsNullOrEmpty(categoryKey))
            {
                modal = db.Listings.Where(x =>x.Category.Name.StartsWith(categoryKey)).
                    Select(x => new searchPlace
                    {
                        id = x.Id,
                        title = x.Title,
                        category = x.Category.Name,
                        categoryIcon = x.Category.Icon,
                        city = x.City.Name,
                        slogan = x.Slogan,
                        lat = x.Lat,
                        lng = x.Lng,
                        comment = x.Comments.ToList(),
                        hours = x.WorkHourses.ToList(),
                        photo = x.Photos.ToList().Take(1),
                        status = x.Status

                    }).ToList();

            }

            if (!string.IsNullOrEmpty(cityKey))
            {
                modal = db.Listings.Where(x => x.City.Name.StartsWith(cityKey)).Select(x => new searchPlace
                {
                    id = x.Id,
                    title = x.Title,
                    category = x.Category.Name,
                    categoryIcon = x.Category.Icon,
                    city = x.City.Name,
                    slogan = x.Slogan,
                    lat = x.Lat,
                    lng = x.Lng,
                    comment = x.Comments.ToList(),
                    hours = x.WorkHourses.ToList(),
                    photo = x.Photos.ToList().Take(1),
                    status = x.Status

                }).ToList();


            }
            return Json(new { status = 200, modal, url = "/SearchPlace/Places" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Places()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            return View();
        }
    }
}