using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Navigation.DAL;
using Navigation.Helper;
using Navigation.Models;

namespace Navigation.Controllers
{
    public class HomeController : Controller
    {
       private  readonly NaviContext db = new NaviContext();
        public ActionResult Index()
        {
           HomeViewModel model = new HomeViewModel();
            model.category = db.Categories.ToList();
            return View(model);
        }

        //categoriya yazanda cixmasi
        [HttpPost]
        public JsonResult GetCategories(string Prefix)
        {

            var category = (from c in db.Categories
                where c.Name.StartsWith(Prefix)
                select new { c.Name, c.Id });
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        //seherlerin yazanda cixmasi
        [HttpPost]
        public JsonResult GetCities(string Prefix)
        {
            var category = (from c in db.Cities
                where c.Name.StartsWith(Prefix)
                select new { c.Name, c.Id });
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        //about index
        public ActionResult About()
        {
           

            return View();
        }

        //contact index
        public ActionResult Contact()
        {
            return View();
        }

       


        //contact mail gonderme
        public ActionResult Send(string Fullname,string Email,string Subject,string Message)
        {
            if (string.IsNullOrEmpty(Fullname) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Message))
            {
                Session["Error"] = "Boş boş  vaxtımı alma";
                return RedirectToAction("Index");
            }

            var body = "<p>Fullname: {0} <br> Email: {1}<br>Subject: {2}<br/> Message: {3}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("ruslan.berz@gmail.com")); // replace with valid value 
            message.From = new MailAddress(Email); // replace with valid value
            message.Subject = "Contact Message";
            message.Body = string.Format(body, Fullname, Email,Subject, Message);
            message.IsBodyHtml = true;


            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "ruslan.aspnet@gmail.com", // replace with valid value
                    Password = "xxxyyyzzz123@@@123" // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
                return RedirectToAction("index");
            }
        
           

        }
        

        //sistemden cixma
        public ActionResult Logout()
        {
            Session["Login"] = null;
            return RedirectToAction("Index", "Home");
        }       

    }
}