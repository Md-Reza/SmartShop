using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNew.Model
{
    public class EmployeeInformation : BaseEntity
    {
        [Required(ErrorMessage = "Account code is required field.")]
        [StringLength(maximumLength: 50)]
        public string AccountCode { get; set; }

        [Required(ErrorMessage = "User name is required field.")]
        [StringLength(maximumLength: 20)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User email is required field.")]
        [StringLength(maximumLength: 80)]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Password is required field.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "First name is required field.")]
        [StringLength(maximumLength: 30)]

        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "First name is required field.")]
        [StringLength(maximumLength: 30)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required field.")]
        [StringLength(maximumLength: 30)]
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

        [Required(ErrorMessage = "Department is required field.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Designation is required field.")]
        public string Designation { get; set; }
    }
}
