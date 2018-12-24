using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Navigation.DAL;
using Navigation.Models;

namespace Navigation.Controllers
{
    public class AccountController : Controller
    {
      private readonly NaviContext db = new NaviContext();

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
                    Session["Login"] = true;
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index","Home");
        }



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
                if (user.Email==item.Email)
                {
                 ModelState.AddModelError("Email","Bu email artıq var");
                    
                }
            }

            if (ModelState.IsValid)
            {
                user.Status = true;
                string pass= Crypto.HashPassword(user.Password);
                user.Password = pass;
                db.Users.Add(user);
                db.SaveChanges();
                
                Session["User"] = user;
                Session["Login"] = true;

                return RedirectToAction("Index", "Home");

            }

           
            return Redirect("/Home/Index#registered");
        }
    }
}