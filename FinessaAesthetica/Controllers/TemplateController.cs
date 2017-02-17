using FinessaAesthetica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinessaAesthetica.Controllers
{
    [Authorize]
    public class TemplateController : Controller
    {
        //
        // GET: /Template/
        public ActionResult Modal(ModalTemplate model)
        {          
            return View(model);
        }

        public ActionResult ModalForm(ModalTemplate model)
        {
            return View(model);
        }
	}
}