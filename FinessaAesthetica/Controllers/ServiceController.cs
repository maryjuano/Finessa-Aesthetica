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
    public class ServiceController : BaseController
    {       

        // GET: /Service/
        public async Task<ActionResult> Index()
        {
            var services = db.Services.Include(s => s.Status);
            return View(await services.ToListAsync());
        }

        // GET: /Service/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = await db.Services.FindAsync(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: /Service/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description");
            return View();
        }

        // POST: /Service/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ServiceId,Code,Description,Type,Amount,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn,StatusId")] Service service)
        {
            if (ModelState.IsValid)
            {
                service.SetOnCreate(CurrentUserId);
                db.Services.Add(service);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description", service.StatusId);
            return View(service);
        }

        // GET: /Service/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = await db.Services.FindAsync(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description", service.StatusId);          
            ViewBag.CreatedBy = db.Users.SingleOrDefaultAsync(u => u.UserId == service.CreatedById).Result.FullName;
            ViewBag.ModifiedBy = db.Users.SingleOrDefaultAsync(u => u.UserId == service.LastModifiedById).Result.FullName;
            return View(service);
        }

        // POST: /Service/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ServiceId,Code,Description,Type,Amount,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn,StatusId")] Service service)
        {
            if (ModelState.IsValid)
            {
                service.SetOnModified(CurrentUserId);
                db.Entry(service).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description", service.StatusId);
            return View(service);
        }

        // GET: /Service/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = await db.Services.FindAsync(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: /Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Service service = await db.Services.FindAsync(id);
            db.Services.Remove(service);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }     
    }
}
