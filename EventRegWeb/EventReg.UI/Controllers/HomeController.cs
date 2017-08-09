using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventReg.Model.Entities;

namespace EventReg.UI.Controllers
{
    public class HomeController : Controller
    {
        private EventReg.Model.Abstract.IDataRepository db;

        public HomeController()
        {
            db = new EventReg.Model.Concrete.Repository();
        }

        // GET: Home
        public ActionResult Index()
        {
            // TO DO: Maybe some stuff here that tells about the app
            return Content("Coming soon.");
        }

        // TO DO: Create a binder to identify the customer
        public ActionResult App()
        {
            // TO DO: Store the customer ID in javascript so it can be used in angular
            return View();
        }

        // TO DO: Create a binder to identify the customer
        public ActionResult Admin()
        {
            // TO DO: Store the customer ID in javascript so it can be used in angular
            return View();
        }
    }
}