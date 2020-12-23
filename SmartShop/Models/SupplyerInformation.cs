using System;

namespace SmartShop.Models
{
    public class SupplyerInformation : BaseEntity
    {
        public int Id { get; set; }
        public string SupplyerName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonMobileNo { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public byte[] Logo { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
