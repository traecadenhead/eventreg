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
        #region Admins

        public IQueryable<Admin> Admins
        {
            get
            {
                return db.Admins.Where(n => n.Deleted == false).AsQueryable();
            }
        }

        public bool ValidateAdmin(Admin entity)
        {
            bool valid = true;
            if (entity.Email == null || entity.Email.Trim().Length == 0)
            {
                HttpContext.Current.Trace.Warn("Email not found");
                valid = false;
            }
            else if (Admins.Where(n => n.Email == entity.Email).Where(n => n.AdminID != entity.AdminID).FirstOrDefault() != null)
            {
                HttpContext.Current.Trace.Warn("Email already in use");
                valid = false;
            }
            if (entity.AdminID == 0 && (entity.Password == null || entity.Password.Trim().Length == 0))
            {
                HttpContext.Current.Trace.Warn("Password already in use");
                valid = false;
            }
            if (entity.Name == null || entity.Name.Trim().Length == 0)
            {
                HttpContext.Current.Trace.Warn("Name not found");
                valid = false;
            }
            if (entity.Type == null || entity.Type.Trim().Length == 0)
            {
                HttpContext.Current.Trace.Warn("Type not found");
                valid = false;
            }
            return valid;
        }

        public int SaveAdmin(Admin entity)
        {
            try
            {
                if (ValidateAdmin(entity))
                {
                    entity.DateModified = DateTime.Now;
                    if (!String.IsNullOrEmpty(entity.Password) && entity.Password.Length < 50)
                    {
                        entity.Password = CreateSHAHash(entity.Password);
                    }
                    Admin original = db.Admins.Find(entity.AdminID);
                    if (original != null)
                    {
                        string originalPW = original.Password;
                        // Update the original
                        db.Entry(original).CurrentValues.SetValues(entity);
                        if (String.IsNullOrEmpty(entity.Password))
                        {
                            // user didn't enter a password, so don't overwrite what's in the db
                            original.Password = originalPW;
                        }
                    }
                    else
                    {
                        entity.DateCreated = DateTime.Now;
                        db.Admins.Add(entity);
                    }
                    if (db.SaveChanges() > 0)
                    {
                        return entity.AdminID;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Warn(ex.ToString());
            }
            return 0;
        }

        public bool DeleteAdmin(int id)
        {
            try
            {
                var entity = db.Admins.Find(id);
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