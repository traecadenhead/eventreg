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
        #region CustomerAdmins

        public IQueryable<CustomerAdmin> CustomerAdmins
        {
            get
            {
                return db.CustomerAdmins.AsQueryable();
            }
        }

        public bool ValidateCustomerAdmin(CustomerAdmin entity)
        {
            bool valid = true;
            if (entity.CustomerID == 0)
            {
                HttpContext.Current.Trace.Warn("CustomerID not found");
                valid = false;
            }
            if (entity.AdminID == 0)
            {
                HttpContext.Current.Trace.Warn("AdminID not found");
                valid = false;
            }
            return valid;
        }

        public int SaveCustomerAdmin(CustomerAdmin entity)
        {
            try
            {
                if (ValidateCustomerAdmin(entity))
                {
                    entity.DateModified = DateTime.Now;
                    CustomerAdmin original = db.CustomerAdmins.Find(entity.CustomerAdminID);
                    if (original != null)
                    {
                        // Update the original
                        db.Entry(original).CurrentValues.SetValues(entity);
                    }
                    else
                    {
                        entity.DateCreated = DateTime.Now;
                        db.CustomerAdmins.Add(entity);
                    }
                    if (db.SaveChanges() > 0)
                    {
                        return entity.CustomerAdminID;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Warn(ex.ToString());
            }
            return 0;
        }

        public bool DeleteCustomerAdmin(int id)
        {
            try
            {
                var entity = db.CustomerAdmins.Find(id);
                if (entity != null)
                {
                    db.CustomerAdmins.Remove(entity);
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