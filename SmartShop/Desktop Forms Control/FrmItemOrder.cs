using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class FrmItemOrder : DevExpress.XtraEditors.XtraForm
    {
        public List<Products> productName = new List<Products>();
        public List<SellesChild> sellesChild = new List<SellesChild>();
        ProductNameRepository productNameRepository = new ProductNameRepository();
        public List<Image> loadImage = new List<Image>();
        ImageList imageList = new ImageList();
        public int index = 1;
        public FrmItemOrder()
        {
            InitializeComponent();
        }
        private void FrmItemOrder_Load(object sender, EventArgs e)
        {
            imageList.ImageSize = new System.Drawing.Size(200, 100);

            var productList = productNameRepository.Get();

            foreach (var item in productList)
            {
                Image img1 = byteArrayToImage(item.logo);
                imageList.Images.Add(img1);

                listView1.LargeImageList = imageList;

                listView1.Items.Add(new ListViewItem(item.ProductCode.ToString() + " " + item.ProductName.ToString(), index));
                index += 1;
            }
            repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
        }

        private Image byteArrayToImage(byte[] logo)
        {
            using (MemoryStream mStream = new MemoryStream(logo))
            {
                return Image.FromStream(mStream);
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                string text = item.Text;

                int totQty = 0;
                int qty = 1;
                var list = productNameRepository.GetByProductCodeName(text).FirstOrDefault();
                if (sellesChild.Count > 0)
                {
                    var checkReUse = sellesChild.Where(x => x.ProductCode == list.ProductCode).FirstOrDefault();
                    if (checkReUse != null)
                    {
                        checkReUse.Qty = checkReUse.Qty + qty;
                    }
                    else
                    {
                        if (totQty == 0)
                            totQty = qty;
                        sellesChild.Add(new SellesChild()
                        {
                            ProductCode = list.ProductCode,
                            SellingPrice = Convert.ToInt32(list.SellingPrice),
                            Name = list.ProductName,
                            Qty = totQty
                        });
                    }
                }
                else
                {
                    sellesChild.Add(new SellesChild()
                    {
                        ProductCode = list.ProductCode,
                        SellingPrice = Convert.ToInt32(list.SellingPrice),
                        Name = list.ProductName,
                        Qty = totQty + qty
                    });
                }
                gridControl1.Refresh();
                gridControl1.DataSource = sellesChild.ToList();
            }
        }

        private void repositoryItemDeleteButton_Click(object sender, EventArgs e)
        {
            Console.Beep(5000, 800);
            if (XtraMessageBox.Show($"Are you want to delete this item {gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Name) }?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var itemDelete = sellesChild.Where(x => x.ProductCode == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, ProductCode).ToString()).FirstOrDefault();
                sellesChild.Remove(itemDelete);
                gridView1.DeleteSelectedRows();
                gridView1.RefreshData();
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (repositoryItemButtonEdit1.Buttons[0].Caption == "Add")
            {
                XtraMessageBox.Show("Test...");
            }
            else
            {
                XtraMessageBox.Show("Test...2");
            }
        }
    }
}