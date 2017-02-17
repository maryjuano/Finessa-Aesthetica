using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class ModalTemplate
    {
        public string Id { get; set; }
        public string HeaderTitle { get; set; }
        public string HeaderIcon { get; set; }
        public string Body { get; set; }

        public string PartialUrlPath { get; set; }
    }
}