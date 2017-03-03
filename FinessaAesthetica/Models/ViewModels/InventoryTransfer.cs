using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class InventoryTransferViewModel
    {
        public int MainInventoryId { get; set; }
        public int Quantity { get; set; }
        public int BranchId { get; set; }
    }
}