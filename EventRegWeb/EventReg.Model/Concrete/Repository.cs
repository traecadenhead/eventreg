using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using EventReg.Model.Abstract;
using EventReg.Model.Entities;
using System.Web;
using System.Net;
using System.IO;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;
using System.Data;

namespace EventReg.Model.Concrete
{
    public partial class Repository : IDataRepository
    {
        //private EventReg.Model.Entities.EventRegEntities db;

        public Repository()
        {
            //db = new EventRegEntities();
        }
    }
}