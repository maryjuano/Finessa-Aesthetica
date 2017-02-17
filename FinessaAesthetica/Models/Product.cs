using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class Product : RecordInformation
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }
        [Display(Name = "Product Desciption")]
        public string Desciption { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Display(Name = "Color")]
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        [Display(Name = "Unit Measurement")]
        public double UnitMeasurement { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Unit Price")]
        public float UnitPrice { get; set; }
        [DataType(DataType.Currency)]       
        [Display(Name = "SRP")]
        public float StandardRetailPrice { get; set; }
    }
}