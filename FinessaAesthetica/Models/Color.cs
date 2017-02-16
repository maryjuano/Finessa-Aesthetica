using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class Color : BaseDescriptionalModel
    {
        public int ColorId { get; set; }
        [Display(Name = "Color Code")]
        public override string Code { get; set; }
    }
}