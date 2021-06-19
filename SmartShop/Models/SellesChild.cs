using System;

namespace SmartShop.Models
{
    public class SellesChild
    {
        public int SellsId { get; set; }
        public int SellsParId { get; set; }
        public string SellsInvoice { get; set; }
        public string ProductCode { get; set; }
        public string SalesMonth { get; set; }
        public string Name { get; set; }
        public string ColurId { get; set; }
        public Colour Colour { get; set; }
        public string SizeId { get; set; }
        public Size Size { get; set; }
        public string BrandId { get; set; }
        public Brand Brand { get; set; }
        public int Qty { get; set; }
        public int SellingPrice { get; set; }
        public int VatPercent { get; set; }
        public int VatAmount { get; set; }
        public decimal DisCountPercent { get; set; }
        public int DiscountAmount { get; set; }
        public int TotalAmount { get; set; }
        public int PayAmount { get; set; }
        public int ReturnAmount { get; set; }
        public string SellsBy { get; set; }
        public int PurchaseAmount { get; set; }
        public int BenfitAmount { get; set; }
        public int ReturnAmt { get; set; }
        public int ReturnQty { get; set; }
        public Products Products { get; set; }
        public CompanyInformation CompanyInformation { get; set; }
        public SellsParent SellsParent { get; set; }
        public DateTime SellsDate { get; set; }
        public SalesReturn SalesReturn { get; set; }
    }
}
