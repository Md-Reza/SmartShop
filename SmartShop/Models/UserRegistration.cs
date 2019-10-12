using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Models
{
    public class UserRegistration:BaseEntity
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string MobileNo { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public byte EmployeePhoto { get; set; }
        public string DesiCode { get; set; }
    }
}
