using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class PurchaseOrder : RecordInformation
    {
     
        [Key]
        public int PurchaseOrderId { get; set; }

        public string PurchaseOrderNumber { get; set; }
        public string Remarks { get; set; }
        public ICollection<PurchaseOrderItems> PurchaseOrderItems { get; set; }
        public string PurchaseOrderStatus { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public float TotalAmount { get; set; }
        public int TotalProductQuantity { get; set; }

        public override void SetOnCreate(int userId = 1)
        {
            this.CreatedOn = DateTime.UtcNow;
            this.LastModifiedOn = DateTime.UtcNow;
            this.CreatedById = userId;
            this.LastModifiedById = userId;
            this.PurchaseOrderStatus = "Pending";
            this.StatusId = 1;  
        } 
    }

    public class PurchaseOrderItems 
    {
        [Key]
        public int PurchaseOrderItemsId { get; set; }
         [Display(Name = "Product")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Quantity { get; set; }    
        public int PurchaseOrderId { get; set; }
       
    }
}