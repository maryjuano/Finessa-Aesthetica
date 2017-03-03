using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class BranchInventory : BaseInventory
    {
        [Key]
        public int BranchInventoryId { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
    }

    public class MainInventory : BaseInventory
    {
        [Key]
        public int MainInventoryId { get; set; }       
    }

    public class MainInventoryItem
    {
        [Key]
        public int MainInventoryItemId { get; set; }
    }
}