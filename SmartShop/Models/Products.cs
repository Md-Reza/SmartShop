using System;

namespace SmartShop.Models
{
    public class Products : BaseEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public int ReorderLebel { get; set; }
        public byte[] logo { get; set; }
        public CategoriesSetup CategoryName { get; set; }
        public SupplyerInformation SupplyerName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateById { get; set; }
        public bool Status { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal VatPercent { get; set; }
        public string Description { get; set; }
        public Colour Colour { get; set; }
        public Size Size { get; set; }
        public Brand Brand { get; set; }
        public decimal DisCountPercent { get; set; }
        public int BrandId { get; set; }
        public int Qty { get; set; }
        public int ColurId { get; set; }
        public int SizeId { get; set; }
        public int QtyBalance { get; set; }
        public Stock Stock { get; set; }
    }
}
