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
     [Authorize]
    public class MainInventoryController : BaseController
    {       

        // GET: /MainInventory/
        public async Task<ActionResult> Index()
        {
            var maininventories = db.MainInventories.Include(m => m.Product).Include(m => m.Status).Include(m => m.CreatedBy);
            List<MainInventory> inventories = maininventories.ToList();
            return View(await maininventories.ToListAsync());
        }

        // GET: /MainInventory/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var record = db.MainInventories.Include(m => m.Product);

            MainInventory maininventory = await record.FirstAsync(m => m.MainInventoryId == id);

            ViewBag.WebPageTitle = maininventory.Product.ProductCode;           
          
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
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description");
            return View();
        }

        // POST: /MainInventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MainInventoryId,ProductId,Quantity,StatusId,MinimumThreshold,MaximumThreshold")] MainInventory maininventory)
        {
            if (ModelState.IsValid)
            {
                maininventory.SetOnCreate(CurrentUserId);
                // update total amount 
                var iv = await SetTotalAmount(maininventory);
                // create record
                db.MainInventories.Add(iv);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductCode", maininventory.ProductId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description", maininventory.StatusId);
            return View(maininventory);
        }

        // GET: /MainInventory/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var record = db.MainInventories.Include(m => m.Product);

            MainInventory maininventory = await record.FirstAsync(m => m.MainInventoryId == id);

            ViewBag.WebPageTitle = maininventory.Product.ProductCode;          

            if (maininventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductCode", maininventory.ProductId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description", maininventory.StatusId);
            return View(maininventory);
        }

        // POST: /MainInventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MainInventoryId,ProductId,Quantity,StatusId,MinimumThreshold,MaximumThreshold")] MainInventory maininventory)
        {
            if (ModelState.IsValid)
            {
                maininventory.SetOnModified(CurrentUserId);
                // update total amount 
                var iv = await SetTotalAmount(maininventory);
                // update record
                db.Entry(iv).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductCode", maininventory.ProductId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "Description", maininventory.StatusId);
            return View(maininventory);
        }

        // GET: /MainInventory/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainInventory maininventory = await db.MainInventories.FindAsync(id);
            if (maininventory == null)
            {
                return HttpNotFound();
            }
            return View(maininventory);
        }

        // POST: /MainInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MainInventory maininventory = await db.MainInventories.FindAsync(id);
            db.MainInventories.Remove(maininventory);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Transfer()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductCode");
            ViewBag.BranchId = new SelectList(db.Branches, "BranchId", "Name");
            return View();
        }

        private async Task<MainInventory> SetTotalAmount(MainInventory inventory)
        {
            Product product = await db.Products.SingleOrDefaultAsync(p => p.ProductId == inventory.ProductId);

            inventory.SetTotalAmount(product);

            return inventory;
        }             
    }
}
