using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        [Display(Name = "Status")]
        public string Description { get; set; }
    }
}