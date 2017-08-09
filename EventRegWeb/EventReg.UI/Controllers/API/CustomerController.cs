using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using EventReg.Model.Entities;

namespace EventReg.UI.Controllers.API
{
    public class CustomerController : BaseController
    {
        [HttpGet]
        public Customer Get(int id)
        {
            return db.Customers.Where(n => n.CustomerID == id).FirstOrDefault();
        }
    }
}
