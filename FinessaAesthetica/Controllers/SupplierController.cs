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
    public class SupplierController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Supplier/
        public ActionResult Index()
        {
            var suppliers = db.Suppliers.Include(s => s.Status);
            return View(suppliers.ToList());
        }

        // GET: /Supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: /Supplier/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description");
            return View();
        }

        // POST: /Supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SupplierId,Code,Name,Address,TelephoneNumber,MobileNumber,ContactPerson,TIN,StatusId")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", supplier.StatusId);
            return View(supplier);
        }

        // GET: /Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", supplier.StatusId);
            return View(supplier);
        }

        // POST: /Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SupplierId,Code,Name,Address,TelephoneNumber,MobileNumber,ContactPerson,TIN,StatusId")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", supplier.StatusId);
            return View(supplier);
        }

        // GET: /Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: /Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
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
