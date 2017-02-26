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
    public class ColorsController : BaseController
    {        
        // GET: /Colors/
        public async Task<ActionResult> Index()
        {
            var colors = db.Colors.Include(c => c.Status);
            return View(await colors.ToListAsync());
        }

        // GET: /Colors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = await db.Colors.FindAsync(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // GET: /Colors/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description");
            return View();
        }

        // POST: /Colors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ColorId,Code,Description,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn,StatusId")] Color color)
        {
            if (ModelState.IsValid)
            {
                color.SetOnCreate(CurrentUserId);
                db.Colors.Add(color);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", color.StatusId);
            return View(color);
        }

        // GET: /Colors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = await db.Colors.FindAsync(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", color.StatusId);
            ViewBag.CreatedBy = db.Users.SingleOrDefaultAsync(u => u.UserId == color.CreatedById).Result.FullName;
            ViewBag.ModifiedBy = db.Users.SingleOrDefaultAsync(u => u.UserId == color.LastModifiedById).Result.FullName;
            return View(color);
        }

        // POST: /Colors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ColorId,Code,Description,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn,StatusId")] Color color)
        {
            if (ModelState.IsValid)
            {
                color.SetOnModified(CurrentUserId);
                db.Entry(color).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", color.StatusId);
            return View(color);
        }

        // GET: /Colors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Color color = await db.Colors.FindAsync(id);
            if (color == null)
            {
                return HttpNotFound();
            }
            return View(color);
        }

        // POST: /Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Color color = await db.Colors.FindAsync(id);
            db.Colors.Remove(color);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
