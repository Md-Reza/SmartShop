using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
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

                        checkReUse.TotalAmount = (checkReUse.Qty  * Convert.ToInt32( list.SellingPrice));
                        TotalAmountByGrid();
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
                            Qty = totQty,
                            VatAmount = Convert.ToInt32(Math.Round(list.VatPercent * list.SellingPrice)),
                            DiscountAmount = Convert.ToInt32(Math.Round(list.DisCountPercent * list.SellingPrice)),
                            TotalAmount = totQty * Convert.ToInt32(list.SellingPrice)
                        });
                        TotalAmountByGrid();
                    }
                }
                else
                {
                    sellesChild.Add(new SellesChild()
                    { 
                        ProductCode = list.ProductCode,
                        SellingPrice = Convert.ToInt32(list.SellingPrice),
                        Name = list.ProductName,
                        Qty = totQty + qty,
                        VatAmount = Convert.ToInt32(Math.Round(list.VatPercent * list.SellingPrice)),
                        DiscountAmount = Convert.ToInt32(Math.Round(list.DisCountPercent * list.SellingPrice)),
                        TotalAmount = (totQty + qty )* Convert.ToInt32( list.SellingPrice)
                    }) ;
                    TotalAmountByGrid();
                }
                gridControl1.Refresh();
                gridControl1.DataSource = sellesChild.ToList();
                TotalAmountByGrid();
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
                TotalAmountByGrid();
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (repositoryItemButtonEdit1.Buttons[0].Caption == "Add")
            //{
            //    XtraMessageBox.Show("Test...");
            //}
            //else
            //{
            //    XtraMessageBox.Show("Test...2");
            //}
        }
        private void TotalAmountByGrid()
        {
            int sum = 0;
            int qty = 0;
            int vat = 0;
            int dis = 0;
            for (int x = 0; x < gridView1.DataRowCount; x++)
            {
                sum += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["TotalAmount"]));
                qty += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["Qty"]));
                vat += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["VatAmount"]));
                dis += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["DiscountAmount"]));
                txtAmount.EditValue = sum;
                txtTotalQty.EditValue = qty;
                txtVatAmount.EditValue = vat;
                txtTotalDisCountAmount.EditValue = dis;
            }
            if (gridView1.DataRowCount <= 0)
            {
                txtAmount.EditValue = sum;
                txtTotalQty.EditValue = qty;
                txtVatAmount.EditValue = vat;
                txtTotalDisCountAmount.EditValue = dis;
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SellingPrice")
            {
                int qty = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["Qty"]));
                int sellingPrice = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["SellingPrice"]));
                int vatAmount = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["VatAmount"]));
                int disCountAmount = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["DiscountAmount"]));
                int totalAmount = ((qty * sellingPrice) + vatAmount) - disCountAmount;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TotalAmount", totalAmount);

                TotalAmountByGrid();
            }

            if (e.Column.FieldName == "Qty")
            {
                int qty = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["Qty"]));
                int sellingPrice = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["SellingPrice"]));
                int vatAmount = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["VatAmount"]));
                int disCountAmount = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["DiscountAmount"]));
                int totalAmount = ((qty * sellingPrice) + vatAmount) - disCountAmount;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TotalAmount", totalAmount);

                TotalAmountByGrid();
            }
        }

        private void repositoryItemButtonEdit1_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            if (buttonIndex == 1)
            {
                XtraMessageBox.Show("Test...");
                e.Button.Click += Click_Click;
            }
            else
            {
                XtraMessageBox.Show("Test...222");
                //e.Button.Click += Click_Click;
                editor.Click += editor_Click;
            }
        }

        private void editor_Click(object sender, EventArgs e)
        {
            gridView1.CellValueChanged += CellValueChanged_CellValueChanged;
        }

        private void Click_Click(object sender, EventArgs e)
        {
            gridView1.CellValueChanged += CellValueChanged_CellValueChanged;
        }

        private void CellValueChanged_CellValueChanged(object sender, CellValueChangedEventArgs e)
        { 
            if (e.Column.FieldName == "Qty")
            {
                int qty = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["Qty"]));
                int sellingPrice = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["SellingPrice"]));
                int vatAmount = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["VatAmount"]));
                int disCountAmount = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["DiscountAmount"]));
                int totalAmount = ((qty * sellingPrice) + vatAmount) - disCountAmount;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TotalAmount", totalAmount);

                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", qty++);

                TotalAmountByGrid();
            }
        }
    }
}