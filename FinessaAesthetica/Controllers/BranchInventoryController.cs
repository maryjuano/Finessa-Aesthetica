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
    public class BranchInventoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /BranchInventory/
        public ActionResult Index()
        {
            var branchinventory = db.BranchInventory.Include(b => b.Branch).Include(b => b.Product).Include(b => b.Status);
            return View(branchinventory.ToList());
        }

        // GET: /BranchInventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchInventory branchinventory = db.BranchInventory.Find(id);
            if (branchinventory == null)
            {
                return HttpNotFound();
            }
            return View(branchinventory);
        }

        // GET: /BranchInventory/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductCode");
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description");
            return View();
        }

        // POST: /BranchInventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BranchInventoryId,BranchId,ProductId,Quantity,UnitPrice,TotalAmount,StatusId,MinimumThreshold,MaximumThreshold")] BranchInventory branchinventory)
        {
            if (ModelState.IsValid)
            {
                db.BranchInventory.Add(branchinventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", branchinventory.BranchId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductCode", branchinventory.ProductId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", branchinventory.StatusId);
            return View(branchinventory);
        }

        // GET: /BranchInventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchInventory branchinventory = db.BranchInventory.Find(id);
            if (branchinventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", branchinventory.BranchId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductCode", branchinventory.ProductId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", branchinventory.StatusId);
            return View(branchinventory);
        }

        // POST: /BranchInventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BranchInventoryId,BranchId,ProductId,Quantity,UnitPrice,TotalAmount,StatusId,MinimumThreshold,MaximumThreshold")] BranchInventory branchinventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branchinventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", branchinventory.BranchId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductCode", branchinventory.ProductId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", branchinventory.StatusId);
            return View(branchinventory);
        }

        // GET: /BranchInventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchInventory branchinventory = db.BranchInventory.Find(id);
            if (branchinventory == null)
            {
                return HttpNotFound();
            }
            return View(branchinventory);
        }

        // POST: /BranchInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BranchInventory branchinventory = db.BranchInventory.Find(id);
            db.BranchInventory.Remove(branchinventory);
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
