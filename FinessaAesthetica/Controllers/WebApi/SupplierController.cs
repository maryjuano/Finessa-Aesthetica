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
    [Authorize]
    public class SupplierController : BaseApiController
    {       
        // GET api/Supplier
        public IQueryable<Supplier> GetSuppliers()
        {
            return db.Suppliers;
        }

        // GET api/Supplier/5
        [ResponseType(typeof(Supplier))]
        public async Task<IHttpActionResult> GetSupplier(int id)
        {
            Supplier supplier = await db.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        // PUT api/Supplier/5
        public async Task<IHttpActionResult> PutSupplier(int id, Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplier.SupplierId)
            {
                return BadRequest();
            }

            db.Entry(supplier).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
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

        // POST api/Supplier
        [ResponseType(typeof(Supplier))]
        public async Task<IHttpActionResult> PostSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suppliers.Add(supplier);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = supplier.SupplierId }, supplier);
        }

        // DELETE api/Supplier/5
        //[ResponseType(typeof(Supplier))]
        //public async Task<IHttpActionResult> DeleteSupplier(int id)
        //{
        //    //db.Suppliers.
        //    Supplier supplier = await db.Suppliers.FindAsync(id);
        //    if (supplier == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Suppliers.Remove(supplier);
        //    await db.SaveChangesAsync();

        //    return Ok(supplier);
        //}

        [HttpDelete]       
        public async Task<IHttpActionResult> DeleteSuppliers(IEnumerable<Supplier> records)
        {
            try
            {
                foreach (Supplier item in records)
                {
                    db.Entry<Supplier>(item).State = EntityState.Deleted;
                }

                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }        
        }


        private bool SupplierExists(int id)
        {
            return db.Suppliers.Count(e => e.SupplierId == id) > 0;
        }
    }
}