using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NumberPlates.Models;

namespace NumberPlates.Controllers
{
    public class LocalGovernmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LocalGovernments
        public ActionResult Index()
        {
            return View(db.LocalGoverments.ToList());
        }

        // GET: LocalGovernments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalGovernment localGovernment = db.LocalGoverments.Find(id);
            if (localGovernment == null)
            {
                return HttpNotFound();
            }
            return View(localGovernment);
        }

        // GET: LocalGovernments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocalGovernments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code")] LocalGovernment localGovernment)
        {
            if (ModelState.IsValid)
            {
                db.LocalGoverments.Add(localGovernment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(localGovernment);
        }

        // GET: LocalGovernments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalGovernment localGovernment = db.LocalGoverments.Find(id);
            if (localGovernment == null)
            {
                return HttpNotFound();
            }
            return View(localGovernment);
        }

        // POST: LocalGovernments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code")] LocalGovernment localGovernment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localGovernment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(localGovernment);
        }

        // GET: LocalGovernments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalGovernment localGovernment = db.LocalGoverments.Find(id);
            if (localGovernment == null)
            {
                return HttpNotFound();
            }
            return View(localGovernment);
        }

        // POST: LocalGovernments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocalGovernment localGovernment = db.LocalGoverments.Find(id);
            db.LocalGoverments.Remove(localGovernment);
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
