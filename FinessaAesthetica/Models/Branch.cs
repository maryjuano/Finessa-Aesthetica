using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }
        public int Telephone { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}