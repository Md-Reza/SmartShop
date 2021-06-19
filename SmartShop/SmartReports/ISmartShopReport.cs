using SmartShop.Models;
using System;
using System.Collections.Generic;

namespace SmartShop.SmartReports
{
    public interface ISmartShopReport:IDisposable
    {
        IEnumerable<PurchaseChild> GetPurchaseChild(string PurchaseInvoice);
        IEnumerable<PurchaseParent> GetPurchaseParent(string PurchaseInvoice);
        IEnumerable<CompanyInformation> GetCompanyInformation();
        IEnumerable<PurchaseChild> GetPurchaseByDate();
        IEnumerable<PurchaseParent> GetPurchaseHeaderDataByDate(string dateF, string dateT);
        IEnumerable<Products> GetAllProductBarcode();
        IEnumerable<SellesChild> GetAllSellsByChildInvoice(string sellsInvoice);
        IEnumerable<SellsParent> GetAllSellsParentByInvoice(string sellsInvoice);
        IEnumerable<CompanyInformation> GetCompanyProfile();
        IEnumerable<Stock> GetAllStockList();
        IEnumerable<SellsParent> GetAllSalesParentPosInvoice(string sellsInvoice);
        IEnumerable<SellesChild> GetAllSalesChildPosInvoice(string sellsInvoice);
        IEnumerable<MonthSummary> GetByMonthWiseStock(string SalesMonth);
    }
}
