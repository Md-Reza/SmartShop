using System;

namespace SmartShop.Models
{
    public class SellsParent
    {
        public int SellsParId { set; get; }
        public string SellsInvoice { set; get; }
        public DateTime SellsDate { set; get; }
        public string SalesMonth { get; set; }
        public int CustomerName { set; get; }
        public string ContactNo { set; get; }
        public int TotalAmount { set; get; }
        public int PayAmount { set; get; }
        public int ReturnAmount { set; get; }
        public int DueAmount { set; get; }
        public string SellsBy { set; get; }
        public string PcName { set; get; }
        public DateTime CreateDateTime { set; get; }
    }
}
