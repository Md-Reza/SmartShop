using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNew.Model
{
    public class CategoriesSetup:BaseEntity
    {
        public int id { get; set; }
        public string CategoryName { get; set; }
        public byte[] Logo { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string Status { get; set; }

    }
}
