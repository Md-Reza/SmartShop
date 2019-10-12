using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNew.Model
{
    public class BaseEntity
    {
        public Command.DbCommand LastCommand { get; set; }
        public string LastChangedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastChangeDateTime { get; set; }
        public bool IsActive { get; set; }

    }
}
