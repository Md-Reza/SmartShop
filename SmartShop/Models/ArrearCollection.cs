using System;

namespace SmartShop.Models
{
    public class ArrearCollection
    {
        public string CustId { get; set; }
        public string CustomerName { get; set; }
        public DateTime TransactionDate { get; set; }
        public string SalesMonth { get; set; }
        public int DueAmount { get; set; }
        public int PayAmount { get; set; }
        public int LastDueAmount { get; set; }
        public string CreateBy { get; set; }
        public CustomerInformation CustomerInformation { get; set; }
        public CustomerArrear CustomerArrear { get; set; }
    }
}
