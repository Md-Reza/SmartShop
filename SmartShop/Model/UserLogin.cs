using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNew.Model
{
 public class UserLogin : BaseEntity
    {
        public string name { get; set; }
        public string nickName { get; set; }
        public string loginName { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string mobileNo { get; set; }
        public string status { get; set; }
        public string createDate { get; set; }
        public string createBy { get; set; }
        public byte employeePhoto { get; set; }
        public string DesiCode { get; set; }
    }
}
