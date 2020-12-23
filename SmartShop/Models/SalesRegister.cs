using System;

namespace SmartShop.Models
{
    public class SalesRegister
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int TotalAmount { get; set; }
        public decimal SellingPrice { get; set; }
        public int PurchasePrice { get; set; }
        public int VatAmount { get; set; }
        public int DueAmount { get; set; }
        public int DiscountAmount { get; set; }
        public int Qty { get; set; }
        public int PurchaseAmount { get; set; }
        public int BenfitAmount { get; set; }
        public DateTime SellsDate { get; set; }
        public int DiscountPrice { get; set; }
    }
}
