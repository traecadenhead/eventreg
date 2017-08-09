﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using EventReg.Model.Entities;

namespace EventReg.UI.Controllers.API
{
    public class PageController : BaseController
    {
        [HttpGet]
        public Sample Get()
        {
            return new Sample
            {
                Test = "Testing"
            };
        }
    }
}
