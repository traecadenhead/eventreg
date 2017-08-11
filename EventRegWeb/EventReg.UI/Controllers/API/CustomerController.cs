using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using EventReg.Model.Entities;

namespace EventReg.UI.Controllers.API
{
    public class CustomerController : BaseController
    {
        [HttpGet]
        public Customer Get(int id)
        {
            return db.Customers.Where(n => n.CustomerID == id).FirstOrDefault();
        }

        [HttpGet]
        public List<Customer> List()
        {
            return db.Customers.OrderBy(n => n.Name).ToList();
        }

        [HttpPut]
        public int Save(Customer entity)
        {
            return db.SaveCustomer(entity);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return db.DeleteCustomer(id);
        }

        [HttpGet]
        public List<CustomerPref> GetPrefs(int id)
        {
            return db.GetPrefsForCustomer(id);
        }

        [HttpPut]
        public bool SavePrefs(List<CustomerPref> list)
        {
            return db.SavePrefsForCustomer(list);
        }

        [HttpGet]
        public List<CustomerPrefKey> ListKeys()
        {
            return db.CustomerPrefKeys.OrderBy(n => n.Ordinal).ToList();
        }

        [HttpPut]
        public int SaveKey(CustomerPrefKey entity)
        {
            return db.SaveCustomerPrefKey(entity);
        }

        [HttpPut]
        public bool SaveKeys(List<CustomerPrefKey> items)
        {
            foreach (var item in items)
            {
                db.SaveCustomerPrefKey(item);
            }
            return true;
        }

        [HttpDelete]
        public bool DeleteKey(int id)
        {
            return db.DeleteCustomerPrefKey(id);
        }
    }
}
