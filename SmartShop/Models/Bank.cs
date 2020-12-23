using System;
using System.Collections.Generic;

namespace SmartShop.Models
{
    public class Bank
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string BankAddress { get; set; }
        public bool Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDateTime { get; set; }
        public List<BankTransaction> BankTransaction { get; set; }
    }
}
