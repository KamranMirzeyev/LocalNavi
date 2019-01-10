using System;
using System.Collections;
using System.Collections.Generic;
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
    public class SearchPlaceController : Controller
    {
        private readonly NaviContext db = new NaviContext();
        //place search
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
                        commentRat = x.Comments.Count() != 0 ? Math.Round(x.Comments.Average(y => y.Rating), 1) : 0,
                        hours = x.WorkHourses.ToList(),
                        photo = x.Photos.ToList().FirstOrDefault().PlacePhoto,
                        status = x.Status,
                        commentCount = x.Comments.Count()

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
                    commentRat = x.Comments.Count() != 0 ? Math.Round(x.Comments.Average(y => y.Rating), 1) : 0,
                    hours = x.WorkHourses.ToList(),
                    photo = x.Photos.ToList().FirstOrDefault().PlacePhoto,
                    status = x.Status,
                    commentCount = x.Comments.Count()

                }).ToList();


            }
            return Json(new { status = 200, modal, url = "/SearchPlace/Places",search=categoryKey,searchcity=cityKey }, JsonRequestBehavior.AllowGet);
        }

        //place index
        public ActionResult Places()
        {
            vwPlace model = new vwPlace();
            model.Categories = db.Categories.ToList();
            model.Cities = db.Cities.ToList();
            return View(model);
        }

        //filter
        [HttpGet]
        public JsonResult Filter(string categoryKey,string cityKey)
        {
            if (string.IsNullOrEmpty(categoryKey) && string.IsNullOrEmpty(cityKey))
            {
                return Json(new { status = 404, message = "Boş axtarış vermə!" }, JsonRequestBehavior.AllowGet);
            }

            List<searchPlace> modal = new List<searchPlace>();
            if (!string.IsNullOrEmpty(categoryKey))
            {
                modal = db.Listings.Where(x => x.Category.Name.StartsWith(categoryKey)).
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
                        commentRat = x.Comments.Count() != 0 ? Math.Round(x.Comments.Average(y => y.Rating), 1) : 0,
                        hours = x.WorkHourses.ToList(),
                        photo = x.Photos.ToList().FirstOrDefault().PlacePhoto,
                        status = x.Status,
                        commentCount = x.Comments.Count()

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
                    commentRat = x.Comments.Count() != 0 ? Math.Round(x.Comments.Average(y => y.Rating), 1) : 0,
                    hours = x.WorkHourses.ToList(),
                    photo = x.Photos.ToList().FirstOrDefault().PlacePhoto,
                    status = x.Status,
                    commentCount = x.Comments.Count()

                }).ToList();


            }
            return Json(new { status = 200, modal, search = categoryKey, searchcity = cityKey }, JsonRequestBehavior.AllowGet);
        }

        //palce details 
        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
          vwDetails model = new vwDetails();
            model.Listing = db.Listings.Include("Comments").Include("Photos").Include("City").Include("User").Include("WorkHourses").Include("ListServices").Include("Category").FirstOrDefault(x=>x.Id==id);
            if (model.Listing==null)
            {

                return HttpNotFound();
            }

            model.ListServices = db.ListServices.Include("Service").Where(x => x.ListingId == id).ToList();
            model.Comments = db.Comments.Include("CommentPhotos").Include("Reactions").Include("User").Where(x=>x.ListingId==id).ToList();
            if (model.Listing.Comments.Count()!=0)
            {
                ViewBag.Rating = model.Listing.Comments.Average(z => z.Rating);
            }

            

            return View(model);
        }

        //place add comment
        [HttpPost]
        public JsonResult Commet(double Rating, string Text, HttpPostedFileBase[] Photo,int id)
        {
           
            if (Session["Login"]==null)
            {
                return Json(new { status = 401, message = "Sistemə giriş etməmisiniz", }, JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrEmpty(Text) || Text.Length>140)

            {
                return Json(new{status=404,message="Texti boş göndərmə və ya 140 simvoldan artıq istifadə etmə",}, JsonRequestBehavior.AllowGet);
            }

            Comment c = new Comment()
            {
                Text = Text,
                ListingId = id,
                UserId = (int)Session["user"],
                Rating = Convert.ToByte(Rating * 2),
                Time = DateTime.Now
            };

            var uId = (int) Session["user"];
            var u = db.Users.FirstOrDefault(x => x.Id ==uId );
            db.Comments.Add(c);
            db.SaveChanges();

           
            foreach (HttpPostedFileBase files in Photo)
            {
                if (files != null && files.ContentLength > 0)
                {
                    if (files.ContentLength > 2097152)
                    {
                        return Json(new { status = 404, message = "2Mb-dan artıq fayl yükləməyin" }, JsonRequestBehavior.AllowGet);
                    }
                    if (files.ContentType != "image/jpeg" && files.ContentType != "image/png" && files.ContentType != "image/jpg" && files.ContentType != "image/gif")
                    {
                        return Json(new { status = 404, message = "Ancaq .jpg .jpeg .png .gif formatda fayl yükləyin" }, JsonRequestBehavior.AllowGet);
                    }
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + files.FileName;
                    string path = Path.Combine(Server.MapPath("~/Public/images/CommentPhoto"), filename);
                    files.SaveAs(path);



                   CommentPhoto photo =new CommentPhoto()
                    {
                        Photo = filename,
                        CommentId = c.Id
                    };
                    db.CommentPhotos.Add(photo);
                    db.SaveChanges();


                   
                   
                }

               
            }

            var url = "/SearchPlace/Detail/" + id;
            return Json(new {status=200,message="Comment əlavə edildi",url}, JsonRequestBehavior.AllowGet);
        }



        //like comment
        [HttpPost]
        [Auth]
        public JsonResult Hcomment(int CommentId, bool IsAdd)
        {
            if (Session["Login"] == null)
            {
                return Json(new { status = 401, message = "Sistemə giriş etməmisiniz", }, JsonRequestBehavior.AllowGet);
            }

            if (CommentId > 0)
            {
                Reaction reaction = db.Reactions.Where(x => x.CommentId == CommentId).FirstOrDefault();
                if (reaction == null)
                {
                    Reaction brandnew = new Reaction();
                    brandnew.CommentId = CommentId;
                    brandnew.UserId = (int)Session["User"];
                    if (IsAdd)
                    {
                        brandnew.Like = 1;
                    }
                    else
                    {
                        brandnew.Like = 0;
                    }

                    db.Reactions.Add(brandnew);
                    db.SaveChanges();
                }
                else
                {
                    if (IsAdd)
                    {
                        reaction.Like = 1;
                    }
                    else
                    {
                        reaction.Like = 0;
                    }


                    db.SaveChanges();


                }
                var url = "/SearchPlace/Detail/" + CommentId;
                return Json(new


                {
                    url,
                    message = "ok",
                    status = 200,
                }, JsonRequestBehavior.AllowGet);

            }

            return Json(new
            {
                message = "Xiyarxiyar sehvler cixir",
                status = 404
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Auth]
        public JsonResult Uhcomment(int CommentId, bool IsAdd)
        {
            if (Session["Login"] == null)
            {
                return Json(new { status = 401, message = "Sistemə giriş etməmisiniz", }, JsonRequestBehavior.AllowGet);
            }

            if (CommentId > 0)
            {
                Reaction reaction = db.Reactions.Where(x => x.CommentId == CommentId).FirstOrDefault();
                if (reaction == null)
                {
                    Reaction brandnew = new Reaction();
                    brandnew.CommentId = CommentId;
                    brandnew.UserId = (int)Session["User"];
                    if (IsAdd)
                    {
                        brandnew.Like = 2;
                    }
                    else
                    {
                        brandnew.Like = 0;
                    }

                    db.Reactions.Add(brandnew);
                    db.SaveChanges();
                }
                else
                {
                    if (IsAdd)
                    {
                        reaction.Like = 2;
                    }
                    else
                    {
                        reaction.Like = 0;
                    }


                    db.SaveChanges();


                }

                var url = "/SearchPlace/Detail/" + CommentId;

                return Json(new


                {
                    url,
                    message = "ok",
                    status = 200,
                }, JsonRequestBehavior.AllowGet);

            }

            return Json(new
            {
                message = "Xeta baş verdi",
                status = 404
            }, JsonRequestBehavior.AllowGet);
        }



        //yoxlamaq ucun Session nulldisa
        [HttpGet]
       
        public JsonResult CanLike()
        {
            if (Session["Login"]==null)
            {
                return Json(new {status=401,message="Sistemə giriş etməmisiniz!" }, JsonRequestBehavior.AllowGet);
            }
           
            return Json(new {status = 200}, JsonRequestBehavior.AllowGet);
        }

    }
}