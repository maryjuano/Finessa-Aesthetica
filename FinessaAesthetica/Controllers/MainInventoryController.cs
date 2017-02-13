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
    public class MainInventoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /MainInventory/
        public ActionResult Index()
        {
            var maininventories = db.MainInventories.Include(m => m.Product).Include(m => m.Status);
            return View(maininventories.ToList());
        }

        // GET: /MainInventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainInventory maininventory = db.MainInventories.Find(id);
            if (maininventory == null)
            {
                return HttpNotFound();
            }
            return View(maininventory);
        }

        // GET: /MainInventory/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductCode");
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description");
            return View();
        }

        // POST: /MainInventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MainInventoryId,ProductId,Quantity,UnitPrice,TotalAmount,StatusId,MinimumThreshold,MaximumThreshold")] MainInventory maininventory)
        {
            if (ModelState.IsValid)
            {
                db.MainInventories.Add(maininventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductCode", maininventory.ProductId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", maininventory.StatusId);
            return View(maininventory);
        }

        // GET: /MainInventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainInventory maininventory = db.MainInventories.Find(id);
            if (maininventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductCode", maininventory.ProductId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", maininventory.StatusId);
            return View(maininventory);
        }

        // POST: /MainInventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MainInventoryId,ProductId,Quantity,UnitPrice,TotalAmount,StatusId,MinimumThreshold,MaximumThreshold")] MainInventory maininventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maininventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductCode", maininventory.ProductId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", maininventory.StatusId);
            return View(maininventory);
        }

        // GET: /MainInventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainInventory maininventory = db.MainInventories.Find(id);
            if (maininventory == null)
            {
                return HttpNotFound();
            }
            return View(maininventory);
        }

        // POST: /MainInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainInventory maininventory = db.MainInventories.Find(id);
            db.MainInventories.Remove(maininventory);
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
