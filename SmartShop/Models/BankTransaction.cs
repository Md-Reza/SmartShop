using System;

namespace SmartShop.Models
{
    public class BankTransaction
    {
        public string AccountNo { get; set; }
        public DateTime TransDate { get; set; }
        public string SalesMonth { get; set; }
        public int OpeningAmount { get; set; }
        public string TransType { get; set; }
        public int DebitAmount { get; set; }
        public int CreditAmount { get; set; }
        public int MiscAmount { get; set; }
        public int Balance { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDateTime { get; set; }
        public Bank Bank { get; set; }
    }
}
