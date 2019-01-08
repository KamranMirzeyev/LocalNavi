using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Navigation.DAL;
using Navigation.Models;

namespace Navigation.Controllers
{
    public class BlogController : Controller
    {
        private  readonly  NaviContext db = new NaviContext();
        // GET: Blog
        public ActionResult Index()
        {
            List<Blog> blogs = db.Blogs.OrderByDescending(x=>x.Orderby).ToList();
            return View(blogs);
        }

        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }

            Blog blog = db.Blogs.Find(id);
            return View(blog);
        }
    }
}