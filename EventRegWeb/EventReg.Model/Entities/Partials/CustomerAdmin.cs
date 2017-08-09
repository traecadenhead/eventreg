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
    [MetadataType(typeof(CustomerAdminJson))]
    public partial class CustomerAdmin
    {
    }

    public class CustomerAdminJson
    {
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Admin Admin { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Customer Customer { get; set; }
    }
}
