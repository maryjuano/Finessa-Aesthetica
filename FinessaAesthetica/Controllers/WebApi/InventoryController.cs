using FinessaAesthetica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;

namespace FinessaAesthetica.Controllers.WebApi
{
    public class InventoryController : BaseApiController
    {
        [HttpPut]
        public async Task<IHttpActionResult> TransferInventoryItem(InventoryTransferViewModel data)
        {
            try
            {               
                MainInventory mainInventory = await db.MainInventories.FindAsync(data.MainInventoryId);               

                if (mainInventory == null)
                {
                    throw new Exception("Inventory Not Found");

                }

                BranchInventory branchInventory = db.BranchInventories.SingleOrDefault(b => b.BranchId == data.BranchId && b.ProductId == mainInventory.ProductId);

                mainInventory.Quantity -= data.Quantity;

                db.Entry(mainInventory).State = EntityState.Modified;                 

                if (branchInventory == null)
                {                   
                    branchInventory = Mapper.Map<BranchInventory>(mainInventory);
                    branchInventory.BranchId = data.BranchId;
                    branchInventory.Quantity = data.Quantity;
                    db.BranchInventories.Add(branchInventory);                   
                }
                else
                {                   
                    branchInventory.Quantity += data.Quantity;
                    db.Entry(branchInventory).State = EntityState.Modified;
                }

                await db.SaveChangesAsync();                

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private void CreateInventory()
        {

        }

        private void UpdateInventory()
        {

        }
    }
}
