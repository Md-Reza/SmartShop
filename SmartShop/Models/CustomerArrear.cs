using System;

namespace SmartShop.Models
{
   public class CustomerArrear
    {
        public DateTime DueDate { get; set; }
        public string SellsInvoice { get; set; }
        public string SalesMonth { get; set; }
        public int CustId { get; set; }
        public string CustomerName { get; set; }
        public string ContactNo { get; set; }
        public string CustomerPresentAddress { get; set; }
        public int TotalAmount { get; set; }
        public int DueAmount { get; set; }
        public int PayAmount { get; set; }
        public int LastDueAmount { get; set; }
        public CustomerInformation CustomerInformation { get; set; }
    }
}
