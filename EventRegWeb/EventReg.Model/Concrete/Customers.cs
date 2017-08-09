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
        #region Customers

        public IQueryable<Customer> Customers
        {
            get
            {
                return db.Customers.Where(n => n.Deleted == false).AsQueryable();
            }
        }

        public bool ValidateCustomer(Customer entity)
        {
            bool valid = true;
            if (entity.Identifier == null || entity.Identifier.Trim().Length == 0)
            {
                HttpContext.Current.Trace.Warn("Identifier not found");
                valid = false;
            }
            if (entity.Name == null || entity.Name.Trim().Length == 0)
            {
                HttpContext.Current.Trace.Warn("Name not found");
                valid = false;
            }
            return valid;
        }

        public int SaveCustomer(Customer entity)
        {
            try
            {
                if (ValidateCustomer(entity))
                {
                    entity.DateModified = DateTime.Now;
                    Customer original = db.Customers.Find(entity.CustomerID);
                    if (original != null)
                    {
                        // Update the original
                        db.Entry(original).CurrentValues.SetValues(entity);
                    }
                    else
                    {
                        entity.DateCreated = DateTime.Now;
                        db.Customers.Add(entity);
                    }
                    if (db.SaveChanges() > 0)
                    {
                        return entity.CustomerID;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Warn(ex.ToString());
            }
            return 0;
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                var entity = db.Customers.Find(id);
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