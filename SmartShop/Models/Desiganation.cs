using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Models
{
   public class Desiganation : BaseEntity
    {
        public int id { get; set; }
        public  string DesiName { get; set; }
        public string DesiCode { get; set; }
        public string Status { get; set; }
    }
}
