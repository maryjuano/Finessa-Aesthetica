﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class Audit
    {
        public int Id { get; set; }
        public string Entity { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}