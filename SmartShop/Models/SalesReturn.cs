using System;

namespace SmartShop.Models
{
    public class SalesReturn
    {
        public DateTime SellsDate { get; set; }
        public string SalesMonth { get; set; }
        public string SellsInvoice { get; set; }
        public SellsParent SellsParent { get; set; }
        public SellesChild SellesChild { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int VatPercent { get; set; }
        public int VatAmount { get; set; }
        public decimal DisCountPercent { get; set; }
        public int DiscountAmount { get; set; }
        public int Qty { get; set; }
        public int SellingPrice { get; set; }
        public int SalesAmount { get; set; }
        public int TotalAmount { get; set; }
        public string SellsBy { get; set; }
        public string PcName { get; set; }
        public int ReturnAmt { get; set; }
        public int ReturnQty { get; set; }
    }
}
