﻿using System;
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
    public class ListingsController : Controller
    {
        private NaviContext db = new NaviContext();

        // GET: Control/Listings
        public ActionResult Index()
        {
            var listings = db.Listings.Include(l => l.Category).Include(l => l.City).Include(l => l.User).Include(l=>l.Photos).Where(x => x.Status == false).ToList();
            
            return View(listings);
        }

        // GET: Control/Listings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

      

        // GET: Control/Listings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", listing.CategoryId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", listing.CityId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", listing.UserId);
            return View(listing);
        }

        // POST: Control/Listings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Status,Title,Slogan,CategoryId,Website,Description,Facebook,Address,Phone,CityId,UserId,Lat,Lng")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", listing.CategoryId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", listing.CityId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", listing.UserId);
            return View(listing);
        }

        // GET: Control/Listings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: Control/Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Listing listing = db.Listings.Find(id);
            db.Listings.Remove(listing);
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
