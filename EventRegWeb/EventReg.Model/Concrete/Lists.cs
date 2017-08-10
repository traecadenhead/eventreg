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
        public List<ListHolder> GetAdminLists()
        {
            List<ListHolder> list = new List<ListHolder>();
            try
            {
                // preference key types list
                list.Add(GetPreferenceKeyTypesList());
            }
            catch(Exception ex)
            {
                HttpContext.Current.Trace.Warn(ex.ToString());
            }
            return list;
        }

        public ListHolder GetPreferenceKeyTypesList()
        {
            ListHolder holder = new ListHolder { ListID = "PreferenceKeyTypes", Items = new List<ListItem>() };
            try
            {
                holder.Items.Add(new ListItem { Key = "CheckBox", Value = "CheckBox" });
                holder.Items.Add(new ListItem { Key = "Hidden", Value = "Hidden" });
                holder.Items.Add(new ListItem { Key = "TextBox", Value = "TextBox" });
            }
            catch(Exception ex)
            {
                HttpContext.Current.Trace.Warn(ex.ToString());
            }
            return holder;
        }
    }
}