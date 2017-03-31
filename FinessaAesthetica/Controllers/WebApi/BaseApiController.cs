using FinessaAesthetica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FinessaAesthetica.Controllers.WebApi
{
    public class BaseApiController : ApiController
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        //protected void MassDelete<T>(IEnumerable<T> data)
        //{
        //    foreach (var item in data)
        //    {
        //        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        //        //db.Entry(item).State = EntityState.Deleted;
        //    }
        //}


        protected int CurrentUserId
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["App"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Request.Cookies["App"]["userId"]);
                }
                return 0;
            }
        }

        protected string CurrentUserFullName
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["App"] != null)
                {
                    return HttpContext.Current.Request.Cookies["App"]["fullName"];
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
            HttpContext.Current.Response.Cookies.Add(userCookieCredentials);
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
