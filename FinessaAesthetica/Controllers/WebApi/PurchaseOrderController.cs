using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FinessaAesthetica.Models;

namespace FinessaAesthetica.Controllers.WebApi
{
    public class PurchaseOrderController : BaseApiController
    {
        // GET api/PurchaseOrder
        public IQueryable<PurchaseOrder> GetPurchaseOrders()
        {
            return db.PurchaseOrders.Include(p => p.Supplier).Include(p => p.CreatedBy);
        }

        // GET api/PurchaseOrder/5
        [ResponseType(typeof(PurchaseOrder))]
        public async Task<IHttpActionResult> GetPurchaseOrder(int id)
        {
            PurchaseOrder purchaseorder = await db.PurchaseOrders.FindAsync(id);
            if (purchaseorder == null)
            {
                return NotFound();
            }

            return Ok(purchaseorder);
        }

        // PUT api/PurchaseOrder/5
        public async Task<IHttpActionResult> PutPurchaseOrder(int id, PurchaseOrder purchaseorder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseorder.PurchaseOrderId)
            {
                return BadRequest();
            }

            db.Entry(purchaseorder).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/PurchaseOrder/5
        [ResponseType(typeof(PurchaseOrder))]
        public async Task<IHttpActionResult> DeletePurchaseOrder(int id)
        {
            PurchaseOrder purchaseorder = await db.PurchaseOrders.FindAsync(id);
            if (purchaseorder == null)
            {
                return NotFound();
            }

            db.PurchaseOrders.Remove(purchaseorder);
            await db.SaveChangesAsync();

            return Ok(purchaseorder);
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            try
            {
                purchaseOrder.PurchaseOrderNumber = await GeneratePurchaseOrderNumber();
                purchaseOrder.SetOnCreate(CurrentUserId);              
                db.PurchaseOrders.Add(purchaseOrder);
                await db.SaveChangesAsync();                              
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> UpdatePurchaseOrder(IEnumerable<PurchaseOrder> purchaseOrders)
        {
            try
            {
                db.Entry(purchaseOrders).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private async Task<string> GeneratePurchaseOrderNumber()
        {
            var purchaseOrderNumber = await db.PurchaseOrders.OrderByDescending(p => p.CreatedOn).FirstAsync();
            string lastNumber = purchaseOrderNumber.PurchaseOrderNumber;
            string numberOnly = lastNumber.Remove(0, lastNumber.IndexOf('-') + 1);
            int numberResult = Convert.ToInt32(numberOnly);
            int numberResultLength = numberResult.ToString().Length;
            int startIndex = (numberOnly.Length) - numberResultLength;

            numberOnly = numberOnly.Remove(startIndex, numberResultLength);

            numberResult++;

            return string.Format("PO-{0}{1}", numberOnly, numberResult.ToString());
        }

        private bool PurchaseOrderExists(int id)
        {
            return db.PurchaseOrders.Count(e => e.PurchaseOrderId == id) > 0;
        }
    }
}