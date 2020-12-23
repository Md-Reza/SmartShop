namespace SmartShop.Models
{
    public class MonthSummary
    {
        public string SalesMonth { get; set; }
        public int CategoryId { get; set; }
        public CategoriesSetup CategoriesSetup { get; set; }
        public int CompanyId { get; set; }
        public SupplyerInformation SupplyerInformation { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int PurchaseQty { get; set; }
        public int PurchaseAmount { get; set; }
        public int PurchaseVatAmount { get; set; }
        public int PurchaseDiscAmt { get; set; }
        public int SalesQty { get; set; }
        public int SalesAmount { get; set; }
        public int SalesVatAmount { get; set; }
        public int ProfitAmount { get; set; }
        public int SalesDiscAmt { get; set; }
        public int ExpensesAmount { get; set; }
        public int ArrearAmount { get; set; }
        public int ArrearCollAmt { get; set; }
        public int SalaryAmount { get; set; }
    }
}
