using DevExpress.XtraEditors;
using SmartShop.Dtos;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.StockList;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmPurchases : DevExpress.XtraEditors.XtraForm
    {
        ProductNameRepository productNameRepository = new ProductNameRepository();
        PurchaseRepository purchase = new PurchaseRepository();
        GetByAllSequence _getByAllSequence = new GetByAllSequence();
        PurchaseRepository purchaseRepository = new PurchaseRepository();
        IStockList<Stock> stock = new StockRepository();
        private List<PurchaseChild> purchaseChild = new List<PurchaseChild>();
        private List<PurchaseChild> purchaseChildSave = new List<PurchaseChild>();

        public frmPurchases()
        {
            InitializeComponent();
        }
        private void frmPurchases_Load(object sender, EventArgs e)
        {
            LoadSupplyer();
            LoadProducts();
            txtDate.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            txtInvoice.EditValue = DateTime.Now.ToString("yyyyMMdd") + _getByAllSequence.GetByAll().Where(f => f.Code == "Invoice").FirstOrDefault().StartWith;
            txtUserName.EditValue = Settings.Default.UserName;
            btnSave.Enabled = false;
            LoadInvoice();
            gridControl2.DataSource = purchaseRepository.GetByLastPurchase(txtDate.EditValue.ToString());
            layoutControl1.AllowCustomization = false;
        }

        private void LoadSupplyer()
        {
            cmbSupplyer.Properties.DataSource = productNameRepository.GetAllSupplyerInformations().ToList();
            cmbSupplyer.Properties.DisplayMember = "SupplyerName";
            cmbSupplyer.Properties.ValueMember = "Id";
            txtUserName.EditValue = Settings.Default.UserName;
        }

        private void LoadProducts()
        {
            cmbProducts.Properties.DataSource = productNameRepository.GetAllProduct().ToList();
            cmbProducts.Properties.DisplayMember = "ProductName";
            cmbProducts.Properties.ValueMember = "ProductCode";
            txtUserName.EditValue = Settings.Default.UserName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void DbOperation()
        {
            if (!ValidationProvider.Validate()) return;
            if (cmbSupplyer.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $"Please select suppler.");
                return;
            }
            if (txtCompanyInvoicce.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $"Please input company invoice.");
                return;
            }
            if (txtDelivaryBy.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $"Please input delivery by .");
                return;
            }
            if (!purchaseChild.Any()) return;
            {
                purchaseChildSave.Clear();
                PurchaseParent purchaseParent = new PurchaseParent()
                {
                    PurchaseDate = Convert.ToDateTime(txtDate.EditValue),
                    SalesMonth = Convert.ToDateTime(txtDate.EditValue).ToString("yyyyMM"),
                    PurchaseInvoice = txtInvoice.EditValue.ToString(),
                    CompanyInvoice = txtCompanyInvoicce.EditValue.ToString(),
                    SupplyerId = cmbSupplyer.EditValue.ToString(),
                    DelivaryBy = txtDelivaryBy.EditValue.ToString(),
                    CreateBy = Settings.Default.UserName,
                    CreateDate = DateTime.Now,
                    PcName = System.Net.Dns.GetHostName()
                };
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    purchaseChildSave.Add(new PurchaseChild()
                    {
                        PurchaseInvoice = txtInvoice.EditValue.ToString(),
                        ProductCode = gridView1.GetRowCellValue(i, "ProductCode").ToString(),
                        SalesMonth = Convert.ToDateTime(txtDate.EditValue).ToString("yyyyMM"),
                        Qty = Convert.ToInt32(gridView1.GetRowCellValue(i, "Qty")),
                        ProductPrice = Convert.ToInt32(gridView1.GetRowCellValue(i, "ProductPrice")),
                        SellingPrice = Convert.ToInt32(gridView1.GetRowCellValue(i, "SellingPrice")),
                        DiscountPrice = Convert.ToInt32(gridView1.GetRowCellValue(i, "DiscountPrice") == null ? 0 : gridView1.GetRowCellValue(i, "DiscountPrice")),
                        DiscountAmount = Convert.ToInt32(gridView1.GetRowCellValue(i, "DiscountPrice") == null ? 0 : gridView1.GetRowCellValue(i, "DiscountAmount")),
                        TotalAmount = Convert.ToInt32(gridView1.GetRowCellValue(i, "TotalAmount") == null ? 0 : gridView1.GetRowCellValue(i, "TotalAmount")),
                        BrandId = productNameRepository.GetByProductCode(cmbProducts.EditValue.ToString()).FirstOrDefault().BrandId,
                        SizeId = productNameRepository.GetByProductCode(cmbProducts.EditValue.ToString()).FirstOrDefault().SizeId,
                        ColourId = productNameRepository.GetByProductCode(cmbProducts.EditValue.ToString()).FirstOrDefault().ColurId
                    });
                }
                PurchaseCreateDto purchaseCreateDto = new PurchaseCreateDto()
                {
                    purchaseParent = purchaseParent,
                    purchaseChild = purchaseChildSave
                };
                if (purchaseChildSave.Count > 0)
                {
                    purchaseRepository.InsertPurchaseData(purchaseCreateDto);
                    purchaseRepository.InsertPurchaseChild(purchaseChildSave);
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Purchase save successfully", "System Message", new[] { DialogResult.OK }, FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));
                    txtInvoice.EditValue = _getByAllSequence.GetByAll().Where(f => f.Code == "Invoice").FirstOrDefault().StartWith;
                    gridControl2.DataSource = purchaseRepository.GetByLastPurchase(txtDate.EditValue.ToString());
                    gridControl1.DataSource = null;
                    LoadInvoice();
                    purchaseChild.Clear();
                }
            }
        }
        private void LoadInvoice()
        {
            var date = txtDate.DateTime.AddDays(-5).ToString();
            chkInvoice.DataSource = purchaseRepository.GetByAllInvoice(date).ToList();
            chkInvoice.DisplayMember = "PurchaseInvoice";
            chkInvoice.ValueMember = "PurchaseInvoice";
            chkInvoice.SelectedValue = "PurchaseInvoice";
        }
        private void LoadByInvoice(string invoice)
        {
            invoice = chkInvoice.CheckedItems[0].ToString();
            var list = purchaseRepository.GetByInvoice(invoice);
            if (list.Any())
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = list.ToList().Select(f => new
                {
                    f.ProductCode,
                    f.PurchaseInvoice,
                    f.PurchasePrice,
                    f.Qty,
                    f.ProductPrice,
                    f.SellingPrice,
                    f.DiscountPrice,
                    f.DiscountAmount,
                    f.TotalAmount
                });
            }
            btnSave.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
            gridView1.RefreshData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbOperation();
            txtInvoice.EditValue = DateTime.Now.ToString("yyyyMMdd") + _getByAllSequence.GetByAll().Where(f => f.Code == "Invoice").FirstOrDefault().StartWith;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Qty")
            {
                int qty = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["Qty"]));
                int sellingPrice = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["SellingPrice"]));
                int disCountAmount = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["DiscountAmount"]));
                int totalAmount = (qty * sellingPrice) - disCountAmount;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TotalAmount", totalAmount);
            }

            if (e.Column.FieldName == "SellingPrice")
            {
                int qty = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["Qty"]));
                int sellingPrice = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["SellingPrice"]));
                int disCountAmount = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["DiscountAmount"]));
                int totalAmount = (qty * sellingPrice) - disCountAmount;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TotalAmount", totalAmount);
            }
            if (e.Column.FieldName == "DiscountAmount")
            {
                int qty = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["Qty"]));
                int sellingPrice = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["SellingPrice"]));
                int disCountAmount = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["DiscountAmount"]));
                int totalAmount = (qty * sellingPrice) - disCountAmount;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TotalAmount", totalAmount);
            }
        }

        private void chkInvoice_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (chkInvoice.CheckedItems.Count == 1)
            {
                string invoiceList = null;
                btnSave.Enabled = false;
                invoiceList = chkInvoice.CheckedItems[0].ToString();
                if (!string.IsNullOrEmpty(invoiceList)) LoadByInvoice(invoiceList);
                else return;
            }
            else return;
        }

        private void chkInvoice_DoubleClick(object sender, EventArgs e)
        {
            chkInvoice.UnCheckAll();
            chkInvoice.CheckOnClick = true;
        }

        private void chkInvoice_Click(object sender, EventArgs e)
        {
            chkInvoice.UnCheckAll();
            chkInvoice.CheckOnClick = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            chkInvoice.UnCheckAll();
            gridControl1.DataSource = null;
            cmbProducts.EditValue = null;
            txtCompanyInvoicce.EditValue = null;
            txtDelivaryBy.EditValue = null;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "Qty")
            {
                int qty = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["Qty"]));
                int sellingPrice = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["SellingPrice"]));
                int disCountAmount = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["DiscountAmount"]));
                int totalAmount = (qty * sellingPrice) - disCountAmount;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TotalAmount", totalAmount);
            }

            if (e.Column.FieldName == "SellingPrice")
            {
                int qty = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["Qty"]));
                int sellingPrice = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["SellingPrice"]));
                int disCountAmount = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["DiscountAmount"]));
                int totalAmount = (qty * sellingPrice) - disCountAmount;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TotalAmount", totalAmount);
            }
            if (e.Column.FieldName == "DiscountAmount")
            {
                int qty = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["Qty"]));
                int sellingPrice = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["SellingPrice"]));
                int disCountAmount = Convert.ToInt32(gridView1.GetListSourceRowCellValue(e.RowHandle, gridView1.Columns["DiscountAmount"]));
                int totalAmount = (qty * sellingPrice) - disCountAmount;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "TotalAmount", totalAmount);
            }
        }

        private void btnBarcodePrint_Click(object sender, EventArgs e)
        {
            frmBarcodeCreate barcodeCreate = new frmBarcodeCreate();
            barcodeCreate.ShowDialog();
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (!ValidationProvider.Validate()) return;

            if (txtDate.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $" Please input purchase date.");
                txtDate.SelectAll();
                txtDate.Focus();
                return;
            }

            if (txtInvoice.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $" Please input company invoice");
                txtInvoice.SelectAll();
                txtInvoice.Focus();
                return;
            }

            if (cmbProducts.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $" Please scan qr code");
                cmbProducts.SelectAll();
                cmbProducts.Focus();
                return;
            }

            IEnumerable<PurchaseChild> purchaseChildren = purchase.GetByAll(Convert.ToString(cmbProducts.EditValue.ToString()));
            if (purchaseChildren.Any())
            {

                repositoryItemButtonEdit3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                if (purchaseChild.Count > 0)
                {
                    var checkReUse = purchaseChild.Where(x => x.ProductCode == cmbProducts.EditValue.ToString()).FirstOrDefault();
                    if (checkReUse != null)
                    {
                        checkReUse.Qty = checkReUse.Qty + Convert.ToInt32(txtQty.EditValue);
                        checkReUse.TotalAmount = (checkReUse.Qty * checkReUse.PurchasePrice);
                        gridControl1.Refresh();
                        gridView1.RefreshData();
                    }
                    else
                    {
                        purchaseChild.Add(new PurchaseChild()
                        {
                            ProductCode = cmbProducts.EditValue.ToString(),
                            PurchaseInvoice = txtInvoice.EditValue.ToString(),
                            Qty = Convert.ToInt32(txtQty.EditValue),
                            PurchasePrice = purchaseChildren.FirstOrDefault().PurchasePrice,
                            SellingPrice = purchaseChildren.FirstOrDefault().SellingPrice,
                            DiscountAmount = 0,
                            DiscountPrice = 0,
                            TotalAmount = purchaseChildren.FirstOrDefault().PurchasePrice * Convert.ToInt16(txtQty.EditValue)
                        });
                    }
                    gridControl1.Refresh();
                    gridView1.RefreshData();
                    gridControl1.DataSource = purchaseChild;
                    btnSave.Enabled = true;
                }
                else
                {
                    purchaseChild.Add(new PurchaseChild()
                    {
                        ProductCode = cmbProducts.EditValue.ToString(),
                        PurchaseInvoice = txtInvoice.EditValue.ToString(),
                        Qty = Convert.ToInt32(txtQty.EditValue),
                        PurchasePrice = purchaseChildren.FirstOrDefault().PurchasePrice,
                        SellingPrice = purchaseChildren.FirstOrDefault().SellingPrice,
                        DiscountAmount = 0,
                        DiscountPrice = 0,
                        TotalAmount = purchaseChildren.FirstOrDefault().PurchasePrice * Convert.ToInt16(txtQty.EditValue)
                    });
                }
                gridControl1.Refresh();
                gridView1.RefreshData();
                gridControl1.DataSource = purchaseChild;
                btnSave.Enabled = true;
            }
            else
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, "Product No not found. Please try with a different product code.");
            }
        }

        private void cmbProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            if (cmbProducts.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $" Please scan qr code");
                cmbProducts.SelectAll();
                cmbProducts.Focus();
                return;
            }

            if (!ValidationProvider.Validate()) return;
            IEnumerable<PurchaseChild> purchaseChildren = purchase.GetByAll(Convert.ToString(cmbProducts.EditValue.ToString()));
            if (purchaseChildren.Any())
            {
                IEnumerable<Stock> information = stock.GetByStockListProductCode(cmbProducts.EditValue.ToString());
                if (information.Any())
                {
                    int totalQty = information.FirstOrDefault().QtyBalance;
                    txtStock.EditValue = totalQty;
                }
                else
                {
                    txtStock.EditValue = 0;
                }
                txtQty.Focus();
                txtQty.SelectAll();
            }
            else
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No product item here...please check product code.", "System Message", new[] { DialogResult.OK }, FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            Console.Beep(5000, 800);
            if (XtraMessageBox.Show($"Are you want to delete this item {gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Name) }?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var itemDelete = purchaseChild.Where(x => x.ProductCode == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, ProductCode).ToString()).FirstOrDefault();
                purchaseChild.Remove(itemDelete);
                gridView1.DeleteSelectedRows();
                gridView1.RefreshData();
            }
        }

        private void repositoryItemButtonEdit3_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            if (buttonIndex == 0)
            {
                int totQty = 0;
                int GridQtySum = 0;

                GridQtySum = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Qty));
                totQty = GridQtySum + 1;
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Qty", totQty);
                gridView1.RefreshData();
            }
            else
            {
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
            }
        }  
    }
}