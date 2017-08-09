using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace EventReg.Model.Entities
{
    [MetadataType(typeof(CustomerJson))]
    public partial class Customer
    {
    }

    public class CustomerJson
    {
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<CustomerAdmin> CustomerAdmins { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<CustomerPref> CustomerPrefs { get; set; }
    }
}
