using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Models
{
    public class EmployeeInformation : BaseEntity
    {
        public string AccountCode { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string EmployeeId { get; set; }
        public string ReportingPerson { get; set; }
        public string Religeon { get; set; }
        public string OfficeLocation { get; set; }
        public string PermanentLocation { get; set; }
        public string MobileNo { get; set; }
        public string IpPhone { get; set; }
        public string DeviceName { get; set; }
        public int DeviceQty { get; set; }
        public string DeviceSerial { get; set; }
        public string DeviceIMEINo1 { get; set; }
        public int BasicSalary { get; set; }
        public int MedicalAllonce { get; set; }
        public int HouseRent { get; set; }
        public int DainingAllonce { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
    }
}
