using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNew.Model
{
   public class ProductName : BaseEntity
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public string Code { get; set; }
        public int CatagoryId { get; set; }
        public int CompanyId { get; set; }
        public int ReorderLebel { get; set; }
        public byte[] logo { get; set; }
        public CategoriesSetup CategoryName { get; set; }
        public SupplyerInformation SupplyerName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateById { get; set; }
        public string Status { get; set; }
        public string ProductPrice { get; set; }
        public string SellingPrice { get; set; }
        public string VatPercent { get; set; }
        public string Description { get; set; }
    }
}
