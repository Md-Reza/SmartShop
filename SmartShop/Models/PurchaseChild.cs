using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Models
{
    public class PurchaseChild
    {
        public string ProductChildCode { get; set; }
        public string PurchaseInvoice { get; set; }
        public int PurchaseId { get; set; }
        public string ProductCode { get; set; }
        public int Qty { get; set; }
        public int ProductPrice { get; set; }
        public int SellingPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int DiscountAmount { get; set; }
        public int TotalAmount { get; set; }
    }
}
