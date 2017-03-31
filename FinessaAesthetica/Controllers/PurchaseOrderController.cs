using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinessaAesthetica.Controllers
{
    public class PurchaseOrderController : BaseController
    {
        //
        // GET: /PurchaseOrder/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {            
            return View();
        }

        public ActionResult Receiving()
        {
            return View();
        }
	}
}