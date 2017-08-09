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
    [MetadataType(typeof(AdminJson))]
    public partial class Admin
    {
        public List<Customer> Customers { get; set; }
    }

    public class AdminJson
    {
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<CustomerAdmin> CustomerAdmins { get; set; }
    }
}
