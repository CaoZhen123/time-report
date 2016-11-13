using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeRecordSystem1.Models;

namespace TimeRecordSystem1.Controllers
{
    public class TimePeriodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TimePeriods
        public ActionResult Index()
        {
            return View(db.TimePeriods.ToList());
        }

        // GET: TimePeriods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimePeriod timePeriod = db.TimePeriods.Find(id);
            if (timePeriod == null)
            {
                return HttpNotFound();
            }
            return View(timePeriod);
        }

        // GET: TimePeriods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimePeriods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate")] TimePeriod timePeriod)
        {
            if (ModelState.IsValid)
            {
                db.TimePeriods.Add(timePeriod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timePeriod);
        }

        // GET: TimePeriods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimePeriod timePeriod = db.TimePeriods.Find(id);
            if (timePeriod == null)
            {
                return HttpNotFound();
            }
            return View(timePeriod);
        }

        // POST: TimePeriods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate")] TimePeriod timePeriod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timePeriod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timePeriod);
        }

        // GET: TimePeriods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimePeriod timePeriod = db.TimePeriods.Find(id);
            if (timePeriod == null)
            {
                return HttpNotFound();
            }
            return View(timePeriod);
        }

        // POST: TimePeriods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimePeriod timePeriod = db.TimePeriods.Find(id);
            db.TimePeriods.Remove(timePeriod);
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
