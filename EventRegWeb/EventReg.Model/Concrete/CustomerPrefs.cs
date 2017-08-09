using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using EventReg.Model.Abstract;
using EventReg.Model.Entities;

namespace EventReg.Model.Concrete
{
    public partial class Repository : IDataRepository
    {
        #region CustomerPrefs

        public IQueryable<CustomerPref> CustomerPrefs
        {
            get
            {
                return db.CustomerPrefs.AsQueryable();
            }
        }

        public bool ValidateCustomerPref(CustomerPref entity)
        {
            bool valid = true;
            if (entity.CustomerID == 0)
            {
                HttpContext.Current.Trace.Warn("CustomerID not found");
                valid = false;
            }
            if (entity.CustomerPrefKeyID == 0)
            {
                HttpContext.Current.Trace.Warn("CustomerPrefKeyID not found");
                valid = false;
            }
            return valid;
        }

        public int SaveCustomerPref(CustomerPref entity)
        {
            try
            {
                if (ValidateCustomerPref(entity))
                {
                    entity.DateModified = DateTime.Now;
                    CustomerPref original = db.CustomerPrefs.Find(entity.CustomerPrefID);
                    if (original != null)
                    {
                        // Update the original
                        db.Entry(original).CurrentValues.SetValues(entity);
                    }
                    else
                    {
                        entity.DateCreated = DateTime.Now;
                        db.CustomerPrefs.Add(entity);
                    }
                    if (db.SaveChanges() > 0)
                    {
                        return entity.CustomerPrefID;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Warn(ex.ToString());
            }
            return 0;
        }

        public bool DeleteCustomerPref(int id)
        {
            try
            {
                var entity = db.CustomerPrefs.Find(id);
                if (entity != null)
                {
                    db.CustomerPrefs.Remove(entity);
                    if (db.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Warn(ex.ToString());
            }
            return false;
        }

        # endregion
    }
}