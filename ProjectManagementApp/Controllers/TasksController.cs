using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagementApp.Models;

namespace ProjectManagementApp.Controllers
{
    public class TasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Taskss
        public ActionResult Index(Guid id)
        {
            ViewBag.ProjectId = id;
            return View(db.Project.Where(e => e.Id == id).Include("Tasks").FirstOrDefault().Tasks);
        }


        // GET: Taskss/Details/5
        public ActionResult Details(Guid? id, Guid pId)
        {
            ViewBag.ProjectId = pId;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks Tasks = db.Tasks.Find(id);
            if (Tasks == null)
            {
                return HttpNotFound();
            }
            return View(Tasks);
        }

        [Authorize(Roles = "ProjectManager")]
        // GET: Taskss/Create
        public ActionResult Create(Guid id)
        {
            ViewBag.ProjectId = id;
            return View();
        }

        // POST: Taskss/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "ProjectManager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guid id, Guid pId, [Bind(Include = "Id,Name,State,AssignedTo,Description,Difficulty")] Tasks Tasks)
        {
            if (ModelState.IsValid)
            {
                Tasks.Id = Guid.NewGuid();
                var dbProject = db.Project.Where(e => e.Id == id).Include("Tasks").FirstOrDefault();
                dbProject.Tasks.Add(Tasks);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = pId });
            }

            return View(Tasks);
        }

        // GET: Taskss/Edit/5
        [Authorize(Roles = "ProjectManager")]
        public ActionResult Edit(Guid? id, Guid pId)
        {
            ViewBag.ProjectId = pId;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks Tasks = db.Tasks.Find(id);
            if (Tasks == null)
            {
                return HttpNotFound();
            }
            return View(Tasks);
        }

        // POST: Taskss/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "ProjectManager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid pId, [Bind(Include = "Id,Name,State,AssignedTo,Description,Difficulty")] Tasks Tasks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Tasks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = pId });
            }
            return View(Tasks);
        }

        // GET: Taskss/Delete/5
        [Authorize(Roles = "ProjectManager")]
        public ActionResult Delete(Guid? id, Guid pId)
        {
            ViewBag.ProjectId = pId;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks Tasks = db.Tasks.Find(id);
            if (Tasks == null)
            {
                return HttpNotFound();
            }
            return View(Tasks);
        }

        // POST: Taskss/Delete/5
        [Authorize(Roles = "ProjectManager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id, Guid pId)
        {
            ViewBag.ProjectId = pId;
            Tasks Tasks = db.Tasks.Find(id);
            db.Tasks.Remove(Tasks);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = pId });
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
