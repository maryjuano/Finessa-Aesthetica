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
        public virtual int CreatedById { get; set; }
        public virtual Users CreatedBy { get; set; }

        [Display(Name = "User")]
        public virtual int LastModifiedById { get; set; }
        public virtual Users LastModifiedBy { get; set; }
        [Display(Name = "Created On")]
        public virtual DateTime CreatedOn { get; set; }
        [Display(Name = "Last Modified")]
        public virtual DateTime LastModifiedOn { get; set; }
        [Display(Name = "Status")]
        public virtual int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public virtual void SetOnCreate(int userId = 1)
        {
            this.CreatedOn = DateTime.UtcNow;
            this.LastModifiedOn = DateTime.UtcNow;
            this.CreatedById = userId;
            this.LastModifiedById = userId;
        }

        public virtual void SetOnModified(int userId = 1)
        {
            this.LastModifiedOn = DateTime.UtcNow;
            this.LastModifiedById = userId;
        }
    }
}