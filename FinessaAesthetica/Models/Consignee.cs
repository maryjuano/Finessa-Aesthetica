using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class Consignee
    {
        [Key]
        public int ConsigneeId { get; set; }
        [Display(Name = "Consignee Code")]
        public string ConsigneeCode { get; set; }
        [Display(Name = "Consignee Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name = "Mobile Number")]
        public int MobileNumber { get; set; }
    }
}