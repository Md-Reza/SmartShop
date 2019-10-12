using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Models
{
    public class ProductName : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public int ReorderLebel { get; set; }
        public byte[] logo { get; set; }
        public CategoriesSetup CategoryName { get; set; }
        public SupplyerInformation SupplyerName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateById { get; set; }
        public string Status { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal VatPercent { get; set; }
        public string Description { get; set; }
        public Colour Colour { get; set; }
        public Size Size { get; set; }
        public Brand Brand { get; set; }
        public decimal DisCountPercent { get; set; }
        public int BrandId { get; set; }
        public int ColourId { get; set; }
        public int SizeId { get; set; }
    }
}
