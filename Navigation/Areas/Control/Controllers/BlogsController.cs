using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
    public class BlogsController : Controller
    {
        private NaviContext db = new NaviContext();

        // GET: Control/Blogs
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        // GET: Control/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Control/Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Control/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Orderby,BigPhoto,SmallPhoto,Title,CreateAt,BlogType,Info")] Blog blog,HttpPostedFileBase BigPhoto,HttpPostedFileBase SmallPhoto)
        {
            if (BigPhoto == null || SmallPhoto == null)
            {
                Session["PhotoError"] = "Şəkil Yükləməmisiniz";
                return RedirectToAction("Create", blog);
            }

            if (SmallPhoto != null)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + SmallPhoto.FileName;
                string path = Path.Combine(Server.MapPath("~/Public/img/blog"), filename);
                SmallPhoto.SaveAs(path);
                blog.SmallPhoto = filename;
            }

            if (BigPhoto != null)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + BigPhoto.FileName;
                string path = Path.Combine(Server.MapPath("~/Public/img/blog"), filename);
                BigPhoto.SaveAs(path);
                blog.BigPhoto = filename;
            }
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();



                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Control/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Control/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Orderby,BigPhoto,SmallPhoto,Title,CreateAt,BlogType,Info")] Blog blog, HttpPostedFileBase BigPhoto, HttpPostedFileBase SmallPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;

                if (SmallPhoto != null)
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + SmallPhoto.FileName;
                    string path = Path.Combine(Server.MapPath("~/Public/img"), filename);
                    SmallPhoto.SaveAs(path);
                    blog.SmallPhoto = filename;
                }
                else
                {
                    db.Entry(blog).Property(x => x.SmallPhoto).IsModified = false;
                }

                if (BigPhoto != null)
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + BigPhoto.FileName;
                    string path = Path.Combine(Server.MapPath("~/Public/img/blog"), filename);
                    BigPhoto.SaveAs(path);
                    blog.BigPhoto = filename;
                }
                else
                {
                    db.Entry(blog).Property(x => x.BigPhoto).IsModified = false;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Control/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Control/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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
