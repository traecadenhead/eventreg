﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Collections.Specialized;
using EventReg.Model.Entities;

namespace EventReg.Model.Abstract
{
    public interface IDataRepository
    {
        #region Admins
        IQueryable<Admin> Admins { get; }
        int SaveAdmin(Admin entity);
        bool DeleteAdmin(int id);
        Admin GetAdminUser(int adminID);
        Admin SignInAdmin(Admin login);
        #endregion

        #region Customers
        IQueryable<Customer> Customers { get; }
        int SaveCustomer(Customer entity);
        bool DeleteCustomer(int id);
        #endregion

        #region CustomerAdmins
        IQueryable<CustomerAdmin> CustomerAdmins { get; }
        int SaveCustomerAdmin(CustomerAdmin entity);
        bool DeleteCustomerAdmin(int id);
        #endregion

        #region CustomerPrefs
        IQueryable<CustomerPref> CustomerPrefs { get; }
        int SaveCustomerPref(CustomerPref entity);
        bool DeleteCustomerPref(int id);
        #endregion

        #region CustomerPrefKeys
        IQueryable<CustomerPrefKey> CustomerPrefKeys { get; }
        int SaveCustomerPrefKey(CustomerPrefKey entity);
        bool DeleteCustomerPrefKey(int id);
        List<CustomerPref> GetPrefsForCustomer(int customerID);
        bool SavePrefsForCustomer(List<CustomerPref> prefs);
        #endregion

        #region Lists
        List<ListHolder> GetAdminLists();
        #endregion
    }
}
