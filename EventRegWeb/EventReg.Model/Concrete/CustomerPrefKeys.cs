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
        #region CustomerPrefKeys

        public IQueryable<CustomerPrefKey> CustomerPrefKeys
        {
            get
            {
                return db.CustomerPrefKeys.Where(n => n.Deleted == false).AsQueryable();
            }
        }

        public bool ValidateCustomerPrefKey(CustomerPrefKey entity)
        {
            bool valid = true;
            if (entity.Type == null || entity.Type.Trim().Length == 0)
            {
                HttpContext.Current.Trace.Warn("Type not found");
                valid = false;
            }
            if (entity.Name == null || entity.Name.Trim().Length == 0)
            {
                HttpContext.Current.Trace.Warn("Name not found");
                valid = false;
            }
            return valid;
        }

        public int SaveCustomerPrefKey(CustomerPrefKey entity)
        {
            try
            {
                if (ValidateCustomerPrefKey(entity))
                {
                    entity.DateModified = DateTime.Now;
                    CustomerPrefKey original = db.CustomerPrefKeys.Find(entity.CustomerPrefKeyID);
                    if (original != null)
                    {
                        // Update the original
                        db.Entry(original).CurrentValues.SetValues(entity);
                    }
                    else
                    {
                        entity.Ordinal = CustomerPrefKeys.OrderByDescending(n => n.Ordinal).Select(n => n.Ordinal).FirstOrDefault() + 1;
                        entity.DateCreated = DateTime.Now;
                        db.CustomerPrefKeys.Add(entity);
                    }
                    if (db.SaveChanges() > 0)
                    {
                        return entity.CustomerPrefKeyID;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Warn(ex.ToString());
            }
            return 0;
        }

        public bool DeleteCustomerPrefKey(int id)
        {
            try
            {
                var entity = db.CustomerPrefKeys.Find(id);
                if (entity != null)
                {
                    entity.Deleted = true;
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