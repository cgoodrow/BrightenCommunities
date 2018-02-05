using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrightenCommunities.Models;

namespace BrightenCommunities.Controllers
{
    public class VolunteersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Volunteers
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.Volunteers.ToList());
        }

        // GET: Volunteers/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteers volunteers = db.Volunteers.Find(id);
            if (volunteers == null)
            {
                return HttpNotFound();
            }
            return View(volunteers);
        }

        // GET: Volunteers/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volunteers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Phone")] Volunteers volunteers)
        {
            if (ModelState.IsValid)
            {
                db.Volunteers.Add(volunteers);
                db.SaveChanges();
                return View();
            }

            return View(volunteers);
        }

        // GET: Volunteers/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteers volunteers = db.Volunteers.Find(id);
            if (volunteers == null)
            {
                return HttpNotFound();
            }
            return View(volunteers);
        }

        // POST: Volunteers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Phone")] Volunteers volunteers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volunteers);
        }

        // GET: Volunteers/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteers volunteers = db.Volunteers.Find(id);
            if (volunteers == null)
            {
                return HttpNotFound();
            }
            return View(volunteers);
        }

        // POST: Volunteers/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volunteers volunteers = db.Volunteers.Find(id);
            db.Volunteers.Remove(volunteers);
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
