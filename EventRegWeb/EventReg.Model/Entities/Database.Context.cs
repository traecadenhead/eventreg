﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventReg.Model.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EventRegEntities : DbContext
    {
        public EventRegEntities()
            : base("name=EventRegEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<CustomerAdmin> CustomerAdmins { get; set; }
        public virtual DbSet<CustomerPrefKey> CustomerPrefKeys { get; set; }
        public virtual DbSet<CustomerPref> CustomerPrefs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
