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
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Product/
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Color).Include(p => p.Supplier);
            return View(products.ToList());
        }

        // GET: /Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Code");
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Code");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Code");
            return View();
        }

        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProductId,Key,Code,Desciption,CategoryId,ColorId,SupplierId,UnitMeasurement,UnitPrice,StandardRetailPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Code", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Code", product.ColorId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Code", product.SupplierId);
            return View(product);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Code", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Code", product.ColorId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Code", product.SupplierId);
            return View(product);
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProductId,Key,Code,Desciption,CategoryId,ColorId,SupplierId,UnitMeasurement,UnitPrice,StandardRetailPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Code", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Code", product.ColorId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Code", product.SupplierId);
            return View(product);
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
