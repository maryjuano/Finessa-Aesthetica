using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Display(Name = "Supplier Code")]
        public string Code { get; set; }
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name = "Telephone Number")]
        public int TelephoneNumber { get; set; }
         [Display(Name = "Mobile Number")]
        public int MobileNumber { get; set; }
         [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        public string TIN { get; set; }
           [Display(Name = "Status")]
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
    }
}