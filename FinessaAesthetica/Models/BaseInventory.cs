using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class BaseInventory
    {
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        private double _totalAmount;

        public virtual double TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = this.Quantity * UnitPrice;
            }
        }
      
        public int StatusId { get; set; }
          [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public int MinimumThreshold { get; set; }
        public int MaximumThreshold { get; set; }
    }
}