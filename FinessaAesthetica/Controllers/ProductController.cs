using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinessaAesthetica.Models;

namespace FinessaAesthetica.Controllers
{
    public class ProductController : BaseController
    {
       

        // GET: /Product/
        public async Task<ActionResult> Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Color).Include(p => p.Status).Include(p => p.Supplier);
            return View(await products.ToListAsync());
        }

        // GET: /Product/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
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
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Code");
            return View();
        }

        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ProductId,ProductCode,Desciption,CategoryId,ColorId,SupplierId,UnitMeasurement,UnitPrice,StandardRetailPrice,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn,StatusId")] Product product)
        {
            if (ModelState.IsValid)
            {               
                product.SetOnCreate(CurrentUserId);
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Code", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Code", product.ColorId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description", product.StatusId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Code", product.SupplierId);
            return View(product);
        }

        // GET: /Product/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Code", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Code", product.ColorId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description", product.StatusId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Code", product.SupplierId);
            return View(product);
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ProductId,ProductCode,Desciption,CategoryId,ColorId,SupplierId,UnitMeasurement,UnitPrice,StandardRetailPrice,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn,StatusId")] Product product)
        {
            if (ModelState.IsValid)
            {               
                product.SetOnModified(CurrentUserId);
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Code", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Code", product.ColorId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description", product.StatusId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Code", product.SupplierId);
            return View(product);
        }

        // GET: /Product/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    
    }
}
