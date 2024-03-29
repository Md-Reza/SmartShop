﻿namespace SmartShop.Models
{
    public class UserLogin : BaseEntity
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string MobileNo { get; set; }
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string CreateBy { get; set; }
        public byte EmployeePhoto { get; set; }
        public string DesiCode { get; set; }
        public string ActiationCode { get; set; }
    }
}
