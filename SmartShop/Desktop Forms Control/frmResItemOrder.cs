using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartShop.Interface.Interface;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmResItemOrder : DevExpress.XtraEditors.XtraForm
    {
        public List<ProductName> productName = new List<ProductName>();
        IBaseRepository<ProductName> baseRepository = new ProductNameRepository();
        ProductNameRepository productNameRepository = new ProductNameRepository();

        public frmResItemOrder()
        {
            InitializeComponent();
        }

        private void frmResItemOrder_Load(object sender, EventArgs e)
        {
            GalleryControl gc = new GalleryControl();
            var productList = productNameRepository.GetAllProduct();

            gc.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            gc.Gallery.ImageSize = new System.Drawing.Size(120, 90);
            gc.Gallery.ShowItemText = true;

            foreach (var item in productList)
            {
                GalleryItemGroup group1 = new GalleryItemGroup();
                group1.Caption = item.CategoryName.ToString();
                gc.Gallery.Groups.Add(group1);
            }
        }
    }
}