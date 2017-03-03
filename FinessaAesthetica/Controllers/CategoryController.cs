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
    public class CategoryController : BaseController
    {    
        // GET: /Category/
        public async Task<ActionResult> Index()
        {
            var categories = db.Categories.Include(c => c.Status);
            return View(await categories.ToListAsync());
        }

        // GET: /Category/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: /Category/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description");
            return View();
        }

        // POST: /Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="CategoryId,Code,Description,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn,StatusId")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.SetOnCreate(CurrentUserId);
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description", category.StatusId);
            return View(category);
        }

        // GET: /Category/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description", category.StatusId);
            ViewBag.CreatedBy = db.Users.SingleOrDefaultAsync(u => u.UserId == category.CreatedById).Result.FullName;
            ViewBag.ModifiedBy = db.Users.SingleOrDefaultAsync(u => u.UserId == category.LastModifiedById).Result.FullName;
            return View(category);
        }

        // POST: /Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="CategoryId,Code,Description,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn,StatusId")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.SetOnModified(CurrentUserId);
                db.Entry(category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description", category.StatusId);
            return View(category);
        }

        // GET: /Category/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: /Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category category = await db.Categories.FindAsync(id);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
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
