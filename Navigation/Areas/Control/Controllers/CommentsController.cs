using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Navigation.DAL;
using Navigation.Helper;
using Navigation.Models;

namespace Navigation.Areas.Control.Controllers
{
    [AuthAdmin]
    public class CommentsController : Controller
    {
        private NaviContext db = new NaviContext();

        // GET: Control/Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Listing).Include(c => c.User).OrderByDescending(c=>c.Id);
            return View(comments.ToList());
        }

        // GET: Control/Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Include(c=>c.User).Include(c=>c.Listing).OrderByDescending(c=>c.Id).FirstOrDefault(x=>x.Id==id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

      

       
        // GET: Control/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Include(x=>x.User).Include(c=>c.Listing).OrderByDescending(c=>c.Id).FirstOrDefault(x=>x.Id==id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Control/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
