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
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductCode");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Code");
            return View();
        }

        public ActionResult Receiving()
        {
            return View();
        }
	}
}