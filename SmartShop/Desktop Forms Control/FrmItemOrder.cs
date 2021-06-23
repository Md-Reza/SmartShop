using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraSplashScreen;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.Interface;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class FrmItemOrder : DevExpress.XtraEditors.XtraForm
    {
        public List<Products> productName = new List<Products>();
        public List<SellesChild> sellesChild = new List<SellesChild>();
        ProductNameRepository productNameRepository = new ProductNameRepository();
        IBaseRepository<CategoriesSetup> categoryRepository = new CategoriesRepository();
        public List<Image> loadImage = new List<Image>();
        ImageList imageList = new ImageList();
        public int index = 0;
        public FrmItemOrder()
        {
            InitializeComponent();
        }
        private void LoadImage()
        {
            listView1.Items.Clear();
            imageList.ImageSize = new System.Drawing.Size(130, 100);

                var productList = productNameRepository.Get();
            
            foreach (var item in productList)
            {
                if (!productList.Any()) return;
                Image img1 = byteArrayToImage(item.logo);
                using (Graphics g = Graphics.FromImage(img1))
                {
                    g.DrawRectangle(Pens.YellowGreen, 0, 0, img1.Width - 2, img1.Height - 2);
                }
                imageList.Images.Add(img1);
                listView1.LargeImageList = imageList;

                listView1.Items.Add(new ListViewItem(item.ProductCode.ToString() + " " + item.ProductName.ToString(), index));
                index += 1;
                Application.DoEvents();  
            }
            repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
        }
        private void LoadImageByCategory(string catName)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), useFadeIn: true, useFadeOut: true);
            imageList.ImageSize = new System.Drawing.Size(130, 100);

            var productList = productNameRepository.GetByCategoryName(catName);
            listView1.Items.Clear();
            listView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            foreach (var item in productList)
            {
                if (!productList.Any()) return;
                Image img1 = byteArrayToImage(item.logo);
                using (Graphics g = Graphics.FromImage(img1))
                {
                    g.DrawRectangle(Pens.YellowGreen, 0, 0, img1.Width - 2, img1.Height - 2);

                    imageList.Images.Add(img1);

                    listView1.LargeImageList = imageList;

                    listView1.Items.Add(new ListViewItem(item.ProductCode.ToString() + " " + item.ProductName.ToString(), index));
                    index += 1;

                }
                Application.DoEvents();
                System.Threading.Thread.Sleep(50);
            }
            repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;

            SplashScreenManager.CloseForm();
        }
        private void FrmItemOrder_Load(object sender, EventArgs e)
        {
            LoadImage();
           
            var allCategory = categoryRepository.Get();
            layoutControlGroup3.Clear();
            foreach (var item in allCategory)
            {
                if (!allCategory.Any())
                    return;

                LayoutControlItem layoutControlItem = layoutControlGroup3.AddItem();
                layoutControlItem.SizeConstraintsType = SizeConstraintsType.Custom;
                layoutControlItem.MaxSize = new System.Drawing.Size(130, 40);
                layoutControlItem.MinSize = new System.Drawing.Size(70, 40);

                SimpleButton simpleButton = new SimpleButton
                {
                    Name = item.CategoryName,
                    Text = item.CategoryName,

                    AppearanceDisabled = {
                            Options = { UseBackColor = true},
                            BackColor = Color.Coral
                        },
                    Font = new Font("Arial", 12, FontStyle.Bold)
                };
                layoutControlItem.Control = simpleButton;
                simpleButton.Click += new EventHandler(Button_Click);
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            SimpleButton editor = (SimpleButton)sender;
            string buttonName = editor.Name.ToString();
            LoadImageByCategory(buttonName);
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
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), useFadeIn: true, useFadeOut: true);

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

                        checkReUse.TotalAmount = (checkReUse.Qty * Convert.ToInt32(list.SellingPrice));
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
                        TotalAmount = (totQty + qty) * Convert.ToInt32(list.SellingPrice)
                    });
                    TotalAmountByGrid();
                }
                gridControl1.Refresh();
                gridControl1.DataSource = sellesChild.ToList();
                TotalAmountByGrid();
            }
            SplashScreenManager.CloseForm();
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
                int sum = 0;
                int qty = 0;
                int vat = 0;
                int dis = 0;
                int totQty = 0;

                int GridQtySum = 0;

                GridQtySum = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Qty));
                totQty = GridQtySum + 1;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", totQty);
                gridView1.RefreshData();
                for (int x = 0; x < gridView1.DataRowCount; x++)
                {
                    sum += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["TotalAmount"]));
                    qty += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["Qty"]));
                    vat += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["VatAmount"]));
                    dis += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["DiscountAmount"]));
                    gridView1.RefreshData();
                    txtAmount.EditValue = sum;
                    txtTotalQty.EditValue = qty;
                    txtVatAmount.EditValue = vat;
                    txtTotalDisCountAmount.EditValue = dis;
                }
                TotalAmountByGrid();
            }
            else
            {
                int sum = 0;
                int qty = 0;
                int vat = 0;
                int dis = 0;
                int totQty = 0;
                int GridQtySum = 0;

                GridQtySum = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Qty));
                totQty = GridQtySum - 1;
                if (totQty <= 0)
                {
                    totQty = 0;
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TotalAmount", 0);
                }

                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", totQty);
                gridView1.RefreshData();

                for (int x = 0; x < gridView1.DataRowCount; x++)
                {
                    sum += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["TotalAmount"]));
                    qty += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["Qty"]));
                    vat += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["VatAmount"]));
                    dis += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["DiscountAmount"]));

                    gridView1.RefreshData();
                    txtAmount.EditValue = sum;
                    txtTotalQty.EditValue = qty;
                    txtVatAmount.EditValue = vat;
                    txtTotalDisCountAmount.EditValue = dis;
                }
                TotalAmountByGrid();
            }
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
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            System.Drawing.Size sz = listView1.LargeImageList.ImageSize;
            int w = sz.Width + 4;
            int h = sz.Height + 3;
            int x = (e.Bounds.Width - sz.Width) / 2 + e.Bounds.X - 2;
            int y = e.Bounds.Top + 1;
            using (Pen pen = new Pen(Color.Red, 2f))
            {
                pen.Alignment = PenAlignment.Center;
                e.Graphics.DrawRectangle(pen, x, y, w, h);
            }
            Application.DoEvents();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), useFadeIn: true, useFadeOut: true);
            LoadImage();
            sellesChild.Clear();
            gridControl1.DataSource = null;
            gridView1.RefreshData();
            SplashScreenManager.CloseForm();
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().ToUpper() == Keys.D.ToString())
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
        }

        private void btnQuickOrder_Click(object sender, EventArgs e)
        {
            frmCalculator frmCalculator = new frmCalculator();
            frmCalculator.Show();
        }
    }
}