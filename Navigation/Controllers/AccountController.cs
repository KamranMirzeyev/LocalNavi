using System;
using System.Collections.Generic;
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
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index","Home");
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
                string pass = Crypto.HashPassword(user.Password);
                user.Password = pass;
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
        public new ActionResult Profile(int id)
        {
            if (id==0)
            {
                return HttpNotFound();
            }
            Models.User u = db.Users.Find(id);
            if (u!=null)
            {
                var place = db.Listings.Where(x => x.UserId == id).ToList();
                return View(place);
            }
            return RedirectToAction("index","Home");
        }
    }
}