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
        public string Code { get; set; }        
        public string Name { get; set; }
        public string Address { get; set; }    
        public int TelephoneNumber { get; set; }
        public int MobileNumber { get; set; }
        public string ContactPerson { get; set; }
        public string TIN { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
    }
}