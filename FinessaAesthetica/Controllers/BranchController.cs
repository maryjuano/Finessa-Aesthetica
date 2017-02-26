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
    public class BranchController : BaseController
    {
        // GET: /Branch/
        public async Task<ActionResult> Index()
        {
            var branches = db.Branches.Include(b => b.Status);
            return View(await branches.ToListAsync());
        }

        // GET: /Branch/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = await db.Branches.FindAsync(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // GET: /Branch/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description");
            return View();
        }

        // POST: /Branch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="BranchId,Name,Code,Address,Manager,Telephone,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn,StatusId")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                branch.SetOnCreate(CurrentUserId);
                db.Branches.Add(branch);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", branch.StatusId);
            return View(branch);
        }

        // GET: /Branch/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = await db.Branches.FindAsync(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", branch.StatusId);
            ViewBag.CreatedBy = db.Users.SingleOrDefaultAsync(u => u.UserId == branch.CreatedById).Result.FullName;
            ViewBag.ModifiedBy = db.Users.SingleOrDefaultAsync(u => u.UserId == branch.LastModifiedById).Result.FullName;
            return View(branch);
        }

        // POST: /Branch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="BranchId,Name,Code,Address,Manager,Telephone,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn,StatusId")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                branch.SetOnModified(CurrentUserId);
                db.Entry(branch).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", branch.StatusId);
            return View(branch);
        }

        // GET: /Branch/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = await db.Branches.FindAsync(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: /Branch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Branch branch = await db.Branches.FindAsync(id);
            db.Branches.Remove(branch);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
