using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class BaseInventory : RecordInformation
    {
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Total Amount")]
        public float TotalAmount { get; set; }
       
        [Display(Name = "Minimum Threshold")]
        public int MinimumThreshold { get; set; }
        [Display(Name = "Maximum Threshold")]
        public int MaximumThreshold { get; set; }
       

        public void SetTotalAmount(Product product)
        {
            this.TotalAmount = this.Quantity * product.UnitPrice;
        }
    }
}