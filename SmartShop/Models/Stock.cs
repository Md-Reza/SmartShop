namespace SmartShop.Models
{
    public sealed class Stock
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public Products Name { get; set; }
        public SupplyerInformation SupplyerInformation { get; set; }
        public string CompanyId { get; set; }
        public string CategoryId { get; set; }
        public CategoriesSetup CategoriesSetup { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ColurId { get; set; }
        public Colour Colour { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public int PurchaseQty { get; set; }
        public int SalesQty { get; set; }
        public int QtyBalance { get; set; }
        public int PurchasesAmount { get; set; }
        public int SalesAmount { get; set; }
        public int BalanceQtyWithReturn { get; set; }
        public int SalesAmountWithReturn { get; set; }
        public int DamageQty { get; set; }
        public int ReturnQty { get; set; }
        public int ReturnAmt { get; set; }
        public int DamageAmt { get; set; }
    }
}
