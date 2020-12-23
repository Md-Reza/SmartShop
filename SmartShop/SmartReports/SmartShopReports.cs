using SmartShop.Models;
using SmartShop.Reports.ReportsRepositories;
using SmartShop.SmartReports.ReportsRepositories;
using System;
using System.Collections.Generic;

namespace SmartShop.SmartReports
{
    public sealed class SmartShopReports
    {
        private static readonly ISmartShopReport _smartShopReport = new PurchaseReportsRepositories();
        private static readonly Register _smartShopRegister = new RegisterRepository();

        public static IEnumerable<PurchaseParent> GetPurchaseParent(string purchaseInvoice)
        {
            return _smartShopReport.GetPurchaseParent(purchaseInvoice);
        }
        public static IEnumerable<PurchaseChild> GetPurchaseParentChild(string purchaseInvoice)
        {
            return _smartShopReport.GetPurchaseChild(purchaseInvoice);
        }

        public static IEnumerable<PurchaseChild> GetPurchaseByDate()
        {
            return _smartShopReport.GetPurchaseByDate();
        }
        public static IEnumerable<PurchaseParent> GetPurchaseHeaderDataByDate(string dateF,string dateT)
        {
            return _smartShopReport.GetPurchaseHeaderDataByDate( dateF, dateT);
        }
        public static IEnumerable< CompanyInformation> GetCompanyInformation()
        {
            return _smartShopReport.GetCompanyInformation();
        }
        public static IEnumerable<ProductName> GetAllProductBarcode()
        {
            return _smartShopReport.GetAllProductBarcode();
        }

        public static IEnumerable<SellesChild> GetAllSellsByChildInvoice(string sellsInvoice)
        {
            return _smartShopReport.GetAllSellsByChildInvoice( sellsInvoice);
        }
        public static IEnumerable<SellsParent> GetAllSellsParentByInvoice(string sellsInvoice)
        {
            return _smartShopReport.GetAllSellsParentByInvoice(sellsInvoice);
        }
        public static IEnumerable<CompanyInformation> GetCompanyProfile()
        {
            return _smartShopReport.GetCompanyProfile();
        }
        public static IEnumerable<Stock> GetAllStockList()
        {
            return _smartShopReport.GetAllStockList();
        }

        public static IEnumerable<SellesChild> GetAllSalesChildPosInvoice(string posInvoice)
        {
            return _smartShopReport.GetAllSalesChildPosInvoice(posInvoice);
        }
        public static IEnumerable<SellsParent> GetAllSalesParentPosInvoice(string posInvoice)
        {
            return _smartShopReport.GetAllSalesParentPosInvoice(posInvoice);
        }
        public static IEnumerable<SellesChild> GetAllSalesByDate(DateTime dateF, DateTime dateT)
        {
            return _smartShopRegister.GetAllSalesByDate(dateF,dateT);
        }
        public static IEnumerable<SalesRegister> GetAllPurchaseByDate(string dateF, string dateT)
        {
            return _smartShopRegister.GetAllPurchaseByDate(dateF, dateT);
        }
        public static IEnumerable<ArrearCollection> GetAllDueCollectionByDate(string dateF, string dateT)
        {
            return _smartShopRegister.GetAllDueCollectionByDate(dateF, dateT);
        }
        public static IEnumerable<CustomerArrear> GetAllCustomerArrear()
        {
            return _smartShopRegister.GetAllCustomerArrear();
        }
        public static IEnumerable<ExpensesEntry> GetAllExpensesByDate(string dateF, string dateT)
        {
            return _smartShopRegister.GetAllExpensesByDate(dateF, dateT);
        }
        public static IEnumerable<MonthSummary> GetByMonthWiseStock(string SalesMonth)
        {
            return _smartShopReport.GetByMonthWiseStock(SalesMonth);
        }

    }
}
