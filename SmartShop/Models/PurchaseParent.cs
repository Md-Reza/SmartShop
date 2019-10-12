using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Models
{
    public class PurchaseParent
    {
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchaseInvoice { get; set; }
        public string CompanyInvoice { get; set; }
        public string SupplyerId { get; set; }
        public string DelivaryBy { get; set; }
        public string ContactNo { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string PcName { get; set; }
        public List<PurchaseChild> PurchaseChild { get; set; }
    }
}
