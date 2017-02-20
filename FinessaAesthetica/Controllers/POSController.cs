using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinessaAesthetica.Controllers
{
    [Authorize]
    public class POSController : BaseController
    {
        //
        // GET: /POS/
        public ActionResult Index()
        {
            return View();
        }
	}
}