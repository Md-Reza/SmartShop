using System;

namespace SmartShop.Models
{
    public class DamageList
    {
        public DateTime EntryDate { get; set; }
        public string SalesMonth { get; set; }
        public SellsParent SellsParent { get; set; }
        public SellesChild SellesChild { get; set; }
        public string ProductCode { get; set; }
        public ProductName Product { get; set; }
        public string ProductName { get; set; }
        public Stock Stock { get; set; }
        public int Qty { get; set; }
        public int PurchasePrice { get; set; }
        public int SellingPrice { get; set; }
        public int SalesAmount { get; set; }
        public int TotalAmount { get; set; }
        public string SellsBy { get; set; }
        public string PcName { get; set; }
    }
}
