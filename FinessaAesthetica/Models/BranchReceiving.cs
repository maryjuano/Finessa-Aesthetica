using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class BranchReceiving
    {
        public int BranchReceivingId { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public string BranchReceivingStatus { get; set; }

    }
}