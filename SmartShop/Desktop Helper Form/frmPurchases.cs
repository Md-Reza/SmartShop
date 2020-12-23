using DevExpress.XtraEditors;
using SmartShop.Dtos;
using SmartShop.Interface;
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
        public DataTable dataTable;
        ProductNameRepository productNameRepository = new ProductNameRepository();
        public List<PurchaseChild> listPurchaseChildren = new List<PurchaseChild>();
        PurchaseRepository purchase = new PurchaseRepository();
        GetByAllSequence _getByAllSequence = new GetByAllSequence();
        PurchaseRepository purchaseRepository = new PurchaseRepository();
        IStockList<Stock> stock = new StockRepository();
        
        public frmPurchases()
        {
            InitializeComponent();

            dataTable = new DataTable();
            dataTable.Columns.Add("serial", typeof(int));
            dataTable.Columns.Add("ProductCode", typeof(string));
            dataTable.Columns.Add("PurchaseInvoice", typeof(string));
            dataTable.Columns.Add("Qty", typeof(int));
            dataTable.Columns.Add("PurchasePrice", typeof(int));
            dataTable.Columns.Add("SellingPrice", typeof(int));
            dataTable.Columns.Add("DiscountPrice", typeof(int));
            dataTable.Columns.Add("DiscountAmount", typeof(int));
            dataTable.Columns.Add("TotalAmount", typeof(int));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["serial"] };
            layoutControl1.AllowCustomization = false;
        }

        private void frmPurchases_Load(object sender, EventArgs e)
        {
            LoadSupplyer();
            txtDate.EditValue = DateTime.Now;
            txtInvoice.EditValue = DateTime.Now.ToString("yyyyMMdd") + _getByAllSequence.GetByAll().Where(f => f.Code == "Invoice").FirstOrDefault().StartWith;
            txtUserName.EditValue = Settings.Default.UserName;
            btnSave.Enabled = false;
            LoadSupplyer();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            if (txtCode.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $" Please scan qr code");
                txtCode.SelectAll();
                txtCode.Focus();
                return;
            }

            if (!ValidationProvider.Validate()) return;
            IEnumerable<PurchaseChild> purchaseChildren = purchase.GetByAll(Convert.ToString(txtCode.EditValue.ToString()));
            if (purchaseChildren.Any())
            {
                IEnumerable<Stock> information = stock.GetByStockListProductCode(txtCode.EditValue.ToString());
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

            if (gridView1.RowCount >= 1)
            {
                List<PurchaseChild> purchaseChild = new List<PurchaseChild>();
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
                    purchaseChild.Add(new PurchaseChild()
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
                        BrandId = productNameRepository.GetByProductCode(txtCode.EditValue.ToString()).FirstOrDefault().BrandId,
                        SizeId = productNameRepository.GetByProductCode(txtCode.EditValue.ToString()).FirstOrDefault().SizeId,
                        ColourId = productNameRepository.GetByProductCode(txtCode.EditValue.ToString()).FirstOrDefault().ColurId
                    });
                }
                PurchaseCreateDto purchaseCreateDto = new PurchaseCreateDto()
                {
                    purchaseParent = purchaseParent,
                    purchaseChild = purchaseChild
                };

                purchaseRepository.InsertPurchaseData(purchaseCreateDto);
                purchaseRepository.InsertPurchaseChild(purchaseChild);

               XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Purchase save successfully", "System Message", new[] { DialogResult.OK }, FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));
               
                txtInvoice.EditValue = _getByAllSequence.GetByAll().Where(f => f.Code == "Invoice").FirstOrDefault().StartWith;
                gridControl2.DataSource = purchaseRepository.GetByLastPurchase(txtDate.EditValue.ToString());
                gridControl1.DataSource = null;
                dataTable.Rows.Clear();
                dataTable.Clear();
                LoadInvoice();
            }
            else
            {
                Voice.Speech("Can't performed save into database");
                Console.Beep(5000, 800);
                XtraMessageBox.Show("Can't performed save into database");
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
            txtInvoice.EditValue = DateTime.Now.ToString("yyyyMMdd")+ _getByAllSequence.GetByAll().Where(f => f.Code == "Invoice").FirstOrDefault().StartWith;
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
            dataTable.Rows.Clear();
            dataTable.Clear();
            chkInvoice.UnCheckAll();
            gridControl1.DataSource = null;
            txtCode.EditValue = null;
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

            if (txtCode.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $" Please scan qr code");
                txtCode.SelectAll();
                txtCode.Focus();
                return;
            }

            if ((from DataRow dr in dataTable.Rows
                 where (string)dr["ProductCode"] == txtCode.EditValue.ToString()
                 select (string)dr["ProductCode"]).Any())
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $" Already scan this item..try another item");
                txtCode.SelectAll();
                txtCode.Focus();
                return;
            }

            IEnumerable<PurchaseChild> purchaseChildren = purchase.GetByAll(Convert.ToString(txtCode.EditValue.ToString()));
            if (purchaseChildren.Any())
            {
                if ((from DataRow dr in dataTable.Rows where (string)dr["ProductCode"] == purchaseChildren.FirstOrDefault().ProductCode select (string)dr["ProductCode"]).Count() == 0)
                {
                    DataRow row = dataTable.NewRow();
                    row["serial"] = DefultSettings.GetNewId(dataTable);
                    row["ProductCode"] = txtCode.EditValue.ToString();
                    row["PurchaseInvoice"] = txtInvoice.EditValue;
                    row["Qty"] = txtQty.EditValue;
                    row["PurchasePrice"] = purchaseChildren.FirstOrDefault().PurchasePrice;
                    row["SellingPrice"] = purchaseChildren.FirstOrDefault().SellingPrice;
                    row["DiscountPrice"] = 0;
                    row["DiscountAmount"] = 0;
                    row["TotalAmount"] = purchaseChildren.FirstOrDefault().PurchasePrice * Convert.ToInt16( txtQty.EditValue);
                    dataTable.Rows.Add(row);
                    gridControl1.DataSource = dataTable;
                    txtCode.Focus();
                    txtCode.SelectAll();
                    btnSave.Enabled = true;
                }
                else
                {
                    XtraMessageBox.Show(this, "Duplicate product code please try with different one.");
                    txtCode.SelectAll();
                }
            }
            else
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, "Product No not found. Please try with a different product code.");
            }
        }
    }
}