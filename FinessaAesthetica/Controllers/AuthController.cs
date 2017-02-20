using AutoMapper;
using FinessaAesthetica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FinessaAesthetica.Controllers
{
    public class AuthController : BaseController
    {       
        //
        // GET: /Auth/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {               
                Users result = db.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

                if (result != null)
                {
                    base.SetUserCookie(result);
                    FormsAuthentication.SetAuthCookie(model.UserName, false);                    
                    return Redirect(returnUrl ?? "~/Dashboard/Index");
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }

            // If we got this far, somethingfailed, redisplay form
            return View(model);
        }

      

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

	}
}