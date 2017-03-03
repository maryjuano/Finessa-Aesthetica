//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Description;
//using FinessaAesthetica.Models;

//namespace FinessaAesthetica.Controllers.WebApi
//{
//    public class PurchaseOrderController : BaseApiController
//    {
//        // GET api/PurchaseOrder
//        public IQueryable<PurchaseOrder> GetPurchaseOrders()
//        {
//            return db.PurchaseOrders;
//        }

//        // GET api/PurchaseOrder/5
//        [ResponseType(typeof(PurchaseOrder))]
//        public async Task<IHttpActionResult> GetPurchaseOrder(int id)
//        {
//            PurchaseOrder purchaseorder = await db.PurchaseOrders.FindAsync(id);
//            if (purchaseorder == null)
//            {
//                return NotFound();
//            }

//            return Ok(purchaseorder);
//        }

//        // PUT api/PurchaseOrder/5
//        public async Task<IHttpActionResult> PutPurchaseOrder(int id, PurchaseOrder purchaseorder)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != purchaseorder.PurchaseOrderId)
//            {
//                return BadRequest();
//            }

//            db.Entry(purchaseorder).State = EntityState.Modified;

//            try
//            {
//                await db.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!PurchaseOrderExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST api/PurchaseOrder
//        [ResponseType(typeof(PurchaseOrder))]
//        public async Task<IHttpActionResult> PostPurchaseOrder(PurchaseOrder purchaseorder)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.PurchaseOrders.Add(purchaseorder);
//            await db.SaveChangesAsync();

//            return CreatedAtRoute("DefaultApi", new { id = purchaseorder.PurchaseOrderId }, purchaseorder);
//        }

//        // DELETE api/PurchaseOrder/5
//        [ResponseType(typeof(PurchaseOrder))]
//        public async Task<IHttpActionResult> DeletePurchaseOrder(int id)
//        {
//            PurchaseOrder purchaseorder = await db.PurchaseOrders.FindAsync(id);
//            if (purchaseorder == null)
//            {
//                return NotFound();
//            }

//            db.PurchaseOrders.Remove(purchaseorder);
//            await db.SaveChangesAsync();

//            return Ok(purchaseorder);
//        }     

//        private bool PurchaseOrderExists(int id)
//        {
//            return db.PurchaseOrders.Count(e => e.PurchaseOrderId == id) > 0;
//        }
//    }
//}