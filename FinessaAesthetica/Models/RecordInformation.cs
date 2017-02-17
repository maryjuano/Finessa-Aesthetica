using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public abstract class RecordInformation
    {
        [Display(Name = "User")]
        public virtual int UserId { get; set; }
         [ForeignKey("UserId")]
        public virtual Users CreatedBy { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime LastModifiedBy { get; set; }
        [Display(Name = "Status")]
        public virtual int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
    }
}