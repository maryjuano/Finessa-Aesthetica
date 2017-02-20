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
    public class SupplierController : BaseController
    {       
        // GET: /Supplier/
        public async Task<ActionResult> Index()
        {
            var suppliers = db.Suppliers.Include(s => s.Status).Include(u => u.CreatedBy).Include(u => u.LastModifiedBy);
            return View(await suppliers.ToListAsync());
        }

        // GET: /Supplier/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = await db.Suppliers.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include="SupplierId,Code,Name,Address,TelephoneNumber,MobileNumber,ContactPerson,TIN,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn,StatusId")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", supplier.StatusId);
            return View(supplier);
        }

        // GET: /Supplier/Edit/5
        [ActionName("Edit")]
        public ActionResult EditIndex(int? id)
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
            ViewBag.CreatedBy = db.Users.SingleOrDefaultAsync(u => u.UserId == supplier.CreatedById).Result.FullName;
            ViewBag.ModifiedBy = db.Users.SingleOrDefaultAsync(u => u.UserId == supplier.LastModifiedById).Result.FullName;
            
            return View(supplier);
        }

        // POST: /Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="SupplierId,Code,Name,Address,TelephoneNumber,MobileNumber,ContactPerson,TIN,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn,StatusId")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.SetOnModified(CurrentUserId);
                db.Entry(supplier).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", supplier.StatusId);
            return View(supplier);
        }

        // GET: /Supplier/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = await db.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: /Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Supplier supplier = await db.Suppliers.FindAsync(id);
            db.Suppliers.Remove(supplier);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

       
    }
}
