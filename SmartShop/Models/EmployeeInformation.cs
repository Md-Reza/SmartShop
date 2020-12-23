namespace SmartShop.Models
{
    public class EmployeeInformation : BaseEntity
    {
        public int AccountCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string ReportingPerson { get; set; }
        public string MobileNo { get; set; }
        public string DeviceName { get; set; }
        public int DeviceQty { get; set; }
        public string IMEINo { get; set; }
        public int BasicSalary { get; set; }
        public int MedicalAllonce { get; set; }
        public int HouseRent { get; set; }
        public int DainingAllonce { get; set; }
        public byte[] Photo { get; set; }
        public Departments Departments { get; set; }
        public string DepartmentCode { get; set; }
        public string DesiCode { get; set; }
        public Designations Designations { get; set; }
        public string CreateBy { get; set; }
        public bool UserStatus { get; set; }
    }
}
