using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Key { get; set; }
        public string Code { get; set; }
        public string Desciption { get; set; }
       
        public int CategoryId { get; set; }          
        public Category Category { get; set; }
        public int ColorId { get; set; }        
        public Color Color { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        public double UnitMeasurement { get; set; }
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }
        [DataType(DataType.Currency)]
        public double StandardRetailPrice { get; set; }
    }
}