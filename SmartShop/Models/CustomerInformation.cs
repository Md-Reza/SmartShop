using System;

namespace SmartShop.Models
{
    public class CustomerInformation
    {
        public int CustId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPresentAddress { get; set; }
        public string CustomerPermanentAddress { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public byte[] Photo { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsActive { get; set; }
        public int DueAmount { get; set; }
    }
}
