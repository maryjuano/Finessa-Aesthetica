using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class Category : BaseDescriptionalModel
    {
        public int CategoryId { get; set; }
        [Display(Name = "Category Code")]
        public override string Code { get; set; }
    }
}