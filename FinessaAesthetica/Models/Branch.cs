using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class Branch : RecordInformation
    {
        public int Id { get; set; }
        [Display(Name = "Branch Code")]
        public string Name { get; set; }
        [Display(Name = "Branch Code")]
        public string Code { get; set; }
        public string Address { get; set; }
        [Display(Name = "Branch Manager")]
        public string Manager { get; set; }
        public int Telephone { get; set; }      
    }
}