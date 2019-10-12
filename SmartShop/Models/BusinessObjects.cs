using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Models
{
    public class BusinessObjects : BaseEntity
    {
        public string BusinessObjectCode { get; set; }
       // public virtual Applications Application { get; set; }
        public string BusinessObjectName { get; set; }
        public string ObjectFormName { get; set; }
        public string ObjectFormType { get; set; }
    }

}
