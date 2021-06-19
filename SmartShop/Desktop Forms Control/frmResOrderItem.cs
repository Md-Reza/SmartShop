using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.Interface;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmResOrderItem : DevExpress.XtraEditors.XtraForm
    {
        public List<Products> productName = new List<Products>();
        IBaseRepository<Products> baseRepository = new ProductNameRepository();
        ProductNameRepository productNameRepository = new ProductNameRepository();
        GalleryItemGroup group1 = new GalleryItemGroup();

        public List<string> productNames;

        public frmResOrderItem()
        {
            InitializeComponent();
        }
        public byte[] imgToByteArray(Image img)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                return mStream.ToArray();
            }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }
        private void frmResOrderItem_Load(object sender, EventArgs e)
        {
            // GalleryControl gc = new GalleryControl();
           // GalleryControl gc = new GalleryControl();
            //galleryControl1.Dock = DockStyle.Fill;
            this.Controls.Add(galleryControl1);

            var productList = productNameRepository.Get();

            galleryControl1.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            galleryControl1.Gallery.ImageSize = new System.Drawing.Size(120, 90);
            galleryControl1.Gallery.ShowItemText = true;
            galleryControl1.BorderStyle = new DevExpress.XtraEditors.Controls.BorderStyles();


            
            group1.Caption = "Products";
            galleryControl1.Gallery.Groups.Add(group1);
            foreach (var item in productList)
            {
                galleryControl1.Gallery.Groups.Add(group1);
                Image img1 = byteArrayToImage(item.logo);
                group1.Items.Add(new GalleryItem(img1, item.ProductCode.ToString()+" "+item.ProductName.ToString(), item.SellingPrice.ToString()));
            }
            galleryControl1.MouseClick += MouseClick_MouseClick;
        }

        private void MouseClick_MouseClick(object sender, MouseEventArgs e)
        {
            productNames = new List<string>();

            for (int i = 0; i <= group1.Items.ToList().Count - 1; i++)
            {
                var ProInfo = group1;
               // var list = productNameRepository.GetByProductCodeName(ProInfo).FirstOrDefault();
                //foreach (var item in list)
                //{

                //}

                //productNames.Add(ProInfo);
            }

            //var ProInfoo = group1.CaptionControl.ToString();
            //productNames.Add(ProInfoo);

            //foreach (GalleryItem item in group1.Items.ToList())
            //{
            //    var a= (this.galleryControl1).Focused;
            //    productNames.Add(a.ToString());
            //}
            //var a = (this.galleryControl1).Focused;
            //var a = group1.Items[0].Caption.ToString();
            //   productNames.Add(a.ToString());


            gridControl1.DataSource = productNames;
            XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Smart Shop Alert:- Item Added Successfully", "System Message", new[] { DialogResult.OK },
                  FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));
        }
    }
}