using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinessaAesthetica.Models;

namespace FinessaAesthetica.Controllers
{
     [Authorize]
    public class ServiceController : BaseController
    {    
        // GET: /Service/
        public ActionResult Index()
        {
            var services = db.Services.Include(s => s.Status);
            return View(services.ToList());
        }

        // GET: /Service/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: /Service/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description");
            return View();
        }

        // POST: /Service/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ServiceId,Code,Description,Type,Amount,StatusId")] Service service)
        {
            if (ModelState.IsValid)
            {
                service.SetOnCreate(CurrentUserId);
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", service.StatusId);
            return View(service);
        }

        // GET: /Service/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", service.StatusId);
            return View(service);
        }

        // POST: /Service/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ServiceId,Code,Description,Type,Amount,StatusId")] Service service)
        {
            if (ModelState.IsValid)
            {
                service.SetOnModified(CurrentUserId);
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", service.StatusId);
            return View(service);
        }

        // GET: /Service/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: /Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }     
    }
}
