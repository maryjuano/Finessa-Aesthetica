using FinessaAesthetica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinessaAesthetica.Controllers.WebApi
{
    public class BaseApiController : ApiController
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        //protected void MassDelete<T>(IEnumerable<T> data)
        //{
        //    foreach (T item in data)
        //    {
        //        db.Entry<T>(item).State = System.Data.Entity.EntityState.Deleted;
        //        //db.Entry(item).State = EntityState.Deleted;
        //    }            
        //}

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
