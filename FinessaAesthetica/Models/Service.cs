using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class Service : RecordInformation
    {
        [Key]
        public int ServiceId { get; set; }
        [Display(Name = "Service Code")]
        public string Code { get; set; }
        public string Description { get; set; }
        [Display(Name = "Service Type")]
        public string Type { get; set; }
        [DataType(DataType.Currency)]
        public float Amount { get; set; }       
    }
}