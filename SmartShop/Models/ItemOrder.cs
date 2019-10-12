using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Models
{
    public class ItemOrder : BaseEntity
    {
        public int id { get; set; }
        public string OrderInvoice { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public string Code { get; set; }
        public int Qty { get; set; }
        public int PurchasePrice { get; set; }
        public decimal Vat { get; set; }
        public int VatAmount { get; set; }
        public int Amount { get; set; }
        public DateTime DelivaryDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateById { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string VatPercent { get; set; }
        public ProductName ProductName { get; set; }
        public CategoriesSetup CategoriesSetup { get; set; }
        public SupplyerInformation SupplyerInformation { get; set; }
    }
}
