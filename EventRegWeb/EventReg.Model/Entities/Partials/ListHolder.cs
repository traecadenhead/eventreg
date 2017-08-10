using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReg.Model.Entities
{
    public class ListHolder
    {
        public string ListID { get; set; }
        public List<ListItem> Items { get; set; }
    }
}
