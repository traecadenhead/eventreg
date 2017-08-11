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
    [MetadataType(typeof(CustomerPrefJson))]
    public partial class CustomerPref
    {
        public CustomerPrefKey Key { get; set; }
    }

    public class CustomerPrefJson
    {
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual CustomerPrefKey CustomerPrefKey { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Customer Customer { get; set; }
    }
}
