using FinessaAesthetica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinessaAesthetica.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        protected int CurrentUserId
        {
            get
            {
                if (Request.Cookies["App"] != null)
                {
                   return Convert.ToInt32(Request.Cookies["App"]["userId"]);
                }
                return 0;
            }
        }

        protected string CurrentUserFullName
        {
            get {
                if (Request.Cookies["App"] != null)
                {
                   return Request.Cookies["App"]["fullName"];
                }
                return string.Empty;
            }
            
        }
        protected void SetUserCookie(Users data)
        {
            HttpCookie userCookieCredentials = new HttpCookie("App");
            userCookieCredentials["userId"] = data.UserId.ToString();
            userCookieCredentials["fullName"] = data.FullName;
            userCookieCredentials.Expires.AddMinutes(60);
            Response.Cookies.Add(userCookieCredentials);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}