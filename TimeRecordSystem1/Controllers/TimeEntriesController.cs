using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeRecordSystem1.Models;
using TimeRecordSystem1.ViewModels;

namespace TimeRecordSystem1.Controllers
{
    public class TimeEntriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TimeEntries
        public ActionResult Index()
        {
            
            return View(db.TimeEntries.ToList());
        }

        // GET: TimeEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeEntry timeEntry = db.TimeEntries.Find(id);
            if (timeEntry == null)
            {
                return HttpNotFound();
            }
            return View(timeEntry);
        }

        // GET: TimeEntries/Create
        public ActionResult Create()
        {
            
            var timeEntryCreationViewModel = new TimeEntryCreationViewModel
            {
                
                Projects = db.Projects,
                Users = db.Users
            };

            return View(timeEntryCreationViewModel);
        }

        // POST: TimeEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TimeEntryCreationViewModel timeEntryCreationViewModel)
        {
            if (ModelState.IsValid)
            {
                timeEntryCreationViewModel.TimeEntry.Project = db.Projects.SingleOrDefault(c => c.Id == timeEntryCreationViewModel.SeletctedProjectId);
                timeEntryCreationViewModel.TimeEntry.User =
                    db.Users.SingleOrDefault(c => c.Id == timeEntryCreationViewModel.SelectedUserId);
                db.TimeEntries.Add(timeEntryCreationViewModel.TimeEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeEntryCreationViewModel);
        }

        // GET: TimeEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeEntry timeEntry = db.TimeEntries.Find(id);
            TimeEntryCreationViewModel timeEntryCreationViewModel = new TimeEntryCreationViewModel
            {

                TimeEntry = timeEntry,
                Projects = db.Projects,
                Users = db.Users
            };

            if (timeEntry == null)
            {
                return HttpNotFound();
            }
            return View(timeEntryCreationViewModel);
        }

        // POST: TimeEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TimeEntryCreationViewModel timeEntryCreationViewModel)
        {
            if (ModelState.IsValid)
            {
                var timeEntryInDb = db.TimeEntries.SingleOrDefault(c => c.Id == id);
                if (timeEntryInDb == null)
                    return HttpNotFound();
                timeEntryInDb.Project = db.Projects.SingleOrDefault(c => c.Id == timeEntryCreationViewModel.SeletctedProjectId);
                timeEntryInDb.User = db.Users.SingleOrDefault(c => c.Id == timeEntryCreationViewModel.SelectedUserId);
                timeEntryInDb.Status = timeEntryCreationViewModel.TimeEntry.Status;
                timeEntryInDb.WorkTime = timeEntryCreationViewModel.TimeEntry.WorkTime;
                timeEntryInDb.Comment = timeEntryCreationViewModel.TimeEntry.Comment;
                timeEntryInDb.Date = timeEntryCreationViewModel.TimeEntry.Date;

                //db.Entry(timeEntryCreationViewModel.TimeEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeEntryCreationViewModel);
        }

        // GET: TimeEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeEntry timeEntry = db.TimeEntries.Find(id);
            if (timeEntry == null)
            {
                return HttpNotFound();
            }
            return View(timeEntry);
        }

        // POST: TimeEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeEntry timeEntry = db.TimeEntries.Find(id);
            db.TimeEntries.Remove(timeEntry);
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
