namespace SmartShop.Models
{
    public class PurchaseChild
    {
        public int PChidId { get; set; }
        public string ProductChildCode { get; set; }
        public string PurchaseInvoice { get; set; }
        public string SalesMonth { get; set; }
        public int PurchaseId { get; set; }
        public string ProductCode { get; set; }
        public int Qty { get; set; }
        public int ProductPrice { get; set; }
        public int PurchasePrice { get; set; }
        public int SellingPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int DiscountAmount { get; set; }
        public int TotalAmount { get; set; }
        public int BrandId { get; set; }
        public int ColourId { get; set; }
        public int SizeId { get; set; }
        public Brand Brand { get; set; }
        public Colour Colour { get; set; }
        public Size Size { get; set; }
    }
}
