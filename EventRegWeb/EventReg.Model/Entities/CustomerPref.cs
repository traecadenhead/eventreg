//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class CustomerPref
    {
        public int CustomerPrefID { get; set; }
        public int CustomerID { get; set; }
        public int CustomerPrefKeyID { get; set; }
        public string Value { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
    
        public virtual CustomerPrefKey CustomerPrefKey { get; set; }
        public virtual Customer Customer { get; set; }
    }
}