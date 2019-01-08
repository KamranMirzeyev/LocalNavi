using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Navigation.DAL;
using Navigation.Helper;
using Navigation.Models;

namespace Navigation.Controllers
{
    public class AccountController : Controller
    {
      private readonly NaviContext db = new NaviContext();
        //user login olunmasi
        [HttpPost]
        public ActionResult Login(User user)
        {
            
            string action = ControllerContext.RouteData.Values["action"].ToString();
            string controller = ControllerContext.RouteData.Values["controller"].ToString();

            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return HttpNotFound();
            }

            User u = db.Users.FirstOrDefault(x => x.Email == user.Email);

            if (u != null)
            {
                if (Crypto.VerifyHashedPassword(u.Password, user.Password))
                {
                    Session["user"] = u.Id;
                    Session["Login"] = true;
                    return RedirectToAction("index", "Home");
                }
            }
            return RedirectToAction(action,controller);
        }


        //user register olunmasi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.FullName) || string.IsNullOrEmpty(user.Password))
            {
                return HttpNotFound();
            }

            foreach (var item in db.Users.ToList())
            {
                if (user.Email == item.Email)
                {
                    ModelState.AddModelError("Email", "Bu email artıq var");

                }
            }

            if (ModelState.IsValid)
            {
                user.Status = true;
                user.Photo = "avatar.jpg";
                
                user.Password = Crypto.HashPassword(user.Password);
                db.Users.Add(user);
                db.SaveChanges();

                Session["User"] = user.Id;
                Session["Login"] = true;

                return RedirectToAction("Index", "Home");

            }


            return Redirect("/Home/Index#registered");
        }


        //emailin yoxlanisi 
        [HttpPost]

        public JsonResult EmailControl(string Email)
        {
            User u = db.Users.FirstOrDefault(x => x.Email == Email);

            if (u != null)
            {
                return Json(new
                {
                    valid = false,
                    message = "Bu emaillə artıq qeydiyyatdan keçmisiniz!"
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new {
                valid = true
                
            }, JsonRequestBehavior.AllowGet);
        }


        //add list butonuna girisin olmasi
        [HttpGet]
       
        public JsonResult AccessLogin()
        {
            

            if (Session["Login"]==null)
            {
                return Json(new{status=404}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status=200,
                    url="/Place/AddListing"
                }, JsonRequestBehavior.AllowGet);
            }
           
        }

        //userin oz profili
        [Auth]
        public  ActionResult Profile()
        {
            int id = (int)Session["user"];
           

           
            
            Models.User u = db.Users.Find(id);
            if (u!=null)
            {
               
                List<searchPlace> modal = new List<searchPlace>();

                modal = db.Listings.Where(x =>x.UserId==id ).
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
                        commentRat = x.Comments.Average(c => c.Rating),
                        hours = x.WorkHourses.ToList(),
                        photo = x.Photos.ToList().FirstOrDefault().PlacePhoto,
                        status = x.Status,
                        commentCount = x.Comments.Count()

                    }).ToList();

                
                return View(modal);
                
            }
            return RedirectToAction("index","Home");
        }
    }
}