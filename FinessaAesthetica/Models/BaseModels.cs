using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public abstract class BaseDescriptionalModel
    {        
        public string Code { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
    }
}