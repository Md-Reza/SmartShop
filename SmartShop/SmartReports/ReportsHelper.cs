using SmartShop.Models;
using SmartShop.Reports.ReportsRepositories;
using System.Collections.Generic;
using System.Linq;

namespace SmartShop.Reports
{
    public sealed class ReportsHelper
    {
        PurchaseReportsRepositories purchaseReports = new PurchaseReportsRepositories();
        public IEnumerable<PurchaseParent> GetPurchaseInvoice()
        {
            IEnumerable<PurchaseParent> purchaseParent = null;

            var list = purchaseReports.GetByAllInvoice();
            if (list.Any())
                purchaseParent = list.ToList();

            return purchaseParent;
        }
        public IEnumerable<SellsParent> GeSellsInvoice()
        {
            IEnumerable<SellsParent> sellsInvoice = null;

            var list = purchaseReports.GetAllSellsInvoice();
            if (list.Any())
                sellsInvoice = list.ToList();

            return sellsInvoice;
        }
    }
}
