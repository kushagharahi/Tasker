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
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Project
        public ActionResult Index()
        {
            return View(db.Project.ToList());
        }

        // GET: Project/Create
        [Authorize(Roles = "ProjectManager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "ProjectManager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Project projectModel)
        {
            if (ModelState.IsValid)
            {
                projectModel.Id = Guid.NewGuid();
                db.Project.Add(projectModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectModel);
        }

        // GET: Project/Edit/5
        [Authorize(Roles = "ProjectManager")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project projectModel = db.Project.Find(id);
            if (projectModel == null)
            {
                return HttpNotFound();
            }
            return View(projectModel);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "ProjectManager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Project projectModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectModel);
        }

        // GET: Project/Delete/5
        [Authorize(Roles = "ProjectManager")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project projectModel = db.Project.Find(id);
            if (projectModel == null)
            {
                return HttpNotFound();
            }
            return View(projectModel);
        }

        // POST: Project/Delete/5
        [Authorize(Roles = "ProjectManager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Project projectModel = db.Project.Find(id);
            db.Project.Remove(projectModel);
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
