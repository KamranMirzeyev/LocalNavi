using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Navigation.DAL;
using Navigation.Helper;
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


        //kategoriya servislerini getirir 
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

        [HttpPost]
        public JsonResult AddListing(Listing place, HttpPostedFileBase[] Photo)
        {



            if (string.IsNullOrEmpty(place.Title) || string.IsNullOrEmpty(place.Address) || string.IsNullOrEmpty(place.Description) || string.IsNullOrEmpty(place.Phone) || string.IsNullOrEmpty(place.Slogan) || string.IsNullOrEmpty(place.Website) || string.IsNullOrEmpty(place.Lat) || string.IsNullOrEmpty(place.Lng))
            {
                return Json(new { status = 404, message = "Xanaları boş buraxmayın" }, JsonRequestBehavior.AllowGet);
            }




            place.UserId = (int)Session["user"];
            place.Status = false;
            db.Listings.Add(place);
            db.SaveChanges();


            foreach (HttpPostedFileBase files in Photo)
            {
                if (files != null && files.ContentLength > 0)
                {
                    if (files.ContentLength > 2097152)
                    {
                        return Json(new{status=404,message="2Mb-dan artıq fayl yükləməyin"},JsonRequestBehavior.AllowGet);
                    }
                    if (files.ContentType != "image/jpeg" && files.ContentType!="image/png" && files.ContentType!="image/jpg" && files.ContentType!="image/gif")
                    {
                        return Json(new { status = 404,message="Ancaq .jpg .jpeg .png .gif formatda fayl yükləyin" }, JsonRequestBehavior.AllowGet); 
                    }
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + files.FileName;
                    string path = Path.Combine(Server.MapPath("~/Public/images/PlacePhoto"), filename);
                    files.SaveAs(path);


                    ListPhoto photo = new ListPhoto()
                    {
                        Photo = filename,
                        ListId = place.Id
                    };
                    db.ListPhotos.Add(photo);
                    db.SaveChanges();

                    return Json(new { status = 200, placeId =place.Id  }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { status = 404, message = "Şəkil yükləməmisiniz" }, JsonRequestBehavior.AllowGet);
                }

               
            }

            return Json(new { status = 404, message = "Xəta baş verdi. Zəhmət olmasa birdə cəhd edin" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult create(int[] servis, List<vwHourWeek> WeekArr, int placeId)
        {
            if (WeekArr != null && servis.Count()>0)
            {
                foreach (var item in WeekArr)
                {
                    WorkHour temp = new WorkHour();
                    temp.OpenHour = TimeSpan.Parse(item.OpenHour);
                    temp.CloseHour = TimeSpan.Parse(item.CloseHour);
                    temp.WeekNo = item.WeekNo;
                    temp.ListingId = placeId;
                    db.WorkHours.Add(temp);

                    db.SaveChanges();

                   
                }

                foreach (var item in servis)
                {
                    ListService ls = new ListService();
                    ls.ListingId = placeId;
                    ls.ServiceId = item;
                    db.ListServices.Add(ls);
                    db.SaveChanges();
                }
                return Json(new
                {
                    status = 200,
                    url = "/home/index",
                    message = "Place Succefssfully created. After moderator rewiew it will be available at the website."
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status = 401,
                    message = "Could not get work times,please fill form again"
                }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}