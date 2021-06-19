using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using SmartShop.Interface;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using SmartShop.SmartReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.CustomerInfoInterface;
using static SmartShop.Interface.StockList;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmSales : DevExpress.XtraEditors.XtraForm
    {
        GetByAllSequence _getByAllSequence = new GetByAllSequence();
        SellsRepository _sellsRepository = new SellsRepository();
        IStockList<Stock> stock = new StockRepository();
        ICustRepository<CustomerInformation> _custRepository = new CustomersRepository();
        public DataTable dataTable;
        public frmSales()
        {
            InitializeComponent();

            dataTable = new DataTable();
            dataTable.Columns.Add("serial", typeof(int));
            dataTable.Columns.Add("SellsInvoice", typeof(string));
            dataTable.Columns.Add("SalesMonth", typeof(string));
            dataTable.Columns.Add("ProductCode", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("ColurId", typeof(string));
            dataTable.Columns.Add("SizeId", typeof(string));
            dataTable.Columns.Add("BrandId", typeof(string));
            dataTable.Columns.Add("Qty", typeof(int));
            dataTable.Columns.Add("SellingPrice", typeof(decimal));
            dataTable.Columns.Add("VatPercent", typeof(int));
            dataTable.Columns.Add("VatAmount", typeof(int));
            dataTable.Columns.Add("DiscountPercent", typeof(decimal));
            dataTable.Columns.Add("DiscountAmount", typeof(decimal));
            dataTable.Columns.Add("TotalAmount", typeof(int));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["serial"] };
            layoutControl1.AllowCustomization = false;
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            //SplashScreenManager.ShowForm(this, typeof(WaitForm1), useFadeIn: true, useFadeOut: true);
            txtUserName.EditValue = Settings.Default.UserName;
            txtComputerName.EditValue = System.Net.Dns.GetHostName();
            txtDate.EditValue = DateTime.Now.ToString("dd-MMM-yyyy");
            string date = txtDate.EditValue.ToString();
            txtInvoiceNo.EditValue = _getByAllSequence.GetByAll().Where(f => f.Code == "SInvoice").FirstOrDefault().StartWith;
            gridControl2.DataSource = _sellsRepository.GetByLastSells(date);
            txtProductCode.Focus();
            LoadCustomer();
            // SplashScreenManager.CloseForm();
        }     

        public void LoadCustomer()
        {
            cmbCustomerName.Properties.DataSource = _custRepository.GetAllCustomer();
            cmbCustomerName.Properties.DisplayMember = "CustomerName";
            cmbCustomerName.Properties.ValueMember = "CustId";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //PrintDocument printDocument = new PrintDocument();
            ////  printDocument.PrintPage += PrintDocumentOnPrintPage;
            //printDocument.PrinterSettings.PrinterName = "TestPrinter";
            //printDocument.Print();
            //printDocument.Dispose();
            int number = 5000;
            XtraMessageBox.Show("Amount" + Math.Abs(number)).ToString();
        }

        private void txtProductCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            IEnumerable<Products> listOfProduct = _sellsRepository.GetByAllSellsProduct(Convert.ToString(txtProductCode.EditValue.ToString()));          
            txtProductCode.EditValue = listOfProduct.ToList();
            if (txtProductCode.EditValue == null)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Please scan product code first", "System Message", new[] { DialogResult.OK },
                  FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }

            var code = txtProductCode.EditValue.ToString();
            IEnumerable<Stock> information = stock.GetByStockListProductCode(code);
            if (!information.Any())
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No available qty for this item", "System Message", new[] { DialogResult.OK },
                   FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
            int totalQty = information.FirstOrDefault().QtyBalance;

            if (information.FirstOrDefault().QtyBalance == null)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No available qty for this item", "System Message", new[] { DialogResult.OK },
                         FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
            if (information.FirstOrDefault().QtyBalance == 0)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No available qty for this item", "System Message", new[] { DialogResult.OK },
                                        FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            };
            int Qty = Convert.ToInt32(txtQty.EditValue);
            if (totalQty > Qty)
            {
                IEnumerable<Products> purchaseChildren = _sellsRepository.GetByAllSellsProduct(Convert.ToString(txtProductCode.EditValue.ToString()));
                if (purchaseChildren.Any())
                {
                    DataRow row = dataTable.NewRow();
                    row["serial"] = DefultSettings.GetNewId(dataTable);
                    row["SellsInvoice"] = txtInvoiceNo.EditValue;
                    row["ProductCode"] = txtProductCode.EditValue.ToString();
                    row["SalesMonth"] = Convert.ToDateTime(txtDate.EditValue).ToString("yyyyMM");
                    row["Name"] = purchaseChildren.FirstOrDefault().ProductName;
                    row["ColurId"] = purchaseChildren.FirstOrDefault().ColurId;
                    row["SizeId"] = purchaseChildren.FirstOrDefault().SizeId;
                    row["BrandId"] = purchaseChildren.FirstOrDefault().BrandId;
                    row["Qty"] = txtQty.EditValue;
                    row["SellingPrice"] = purchaseChildren.FirstOrDefault().SellingPrice;
                    row["VatPercent"] = purchaseChildren.FirstOrDefault().VatPercent;
                    row["VatAmount"] = (purchaseChildren.FirstOrDefault().SellingPrice * purchaseChildren.FirstOrDefault().VatPercent) / 100;
                    row["DiscountPercent"] = purchaseChildren.FirstOrDefault().DisCountPercent;
                    row["DiscountAmount"] = (purchaseChildren.FirstOrDefault().SellingPrice * purchaseChildren.FirstOrDefault().DisCountPercent) / 100;
                    var disAmount = (purchaseChildren.FirstOrDefault().SellingPrice * purchaseChildren.FirstOrDefault().DisCountPercent) / 100;
                    var totAmount = (purchaseChildren.FirstOrDefault().SellingPrice * Convert.ToInt32(txtQty.EditValue));
                    var vatAmt = totAmount*purchaseChildren.FirstOrDefault().VatPercent;
                    row["TotalAmount"] = totAmount - disAmount + vatAmt;

                    dataTable.Rows.Add(row);
                    gridControl1.DataSource = dataTable;
                    txtProductCode.Focus();
                    txtProductCode.SelectAll();
                    TotalAmountByGrid();
                }
                else
                {
                    Console.Beep(5000, 800);
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Product No not found. Please try with a different product code.", "System Message", new[] { DialogResult.OK },
                            FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                }
            }
            else
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No available qty for this item", "System Message", new[] { DialogResult.OK },
            FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
        }

        private void DbOperation()
        {
            int returnAmount = Convert.ToInt32(txtReturnAmount.EditValue);
            if (returnAmount < 0)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Pay Amount is less then total amount", "System Message", new[] { DialogResult.OK },
             FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
            if (txtTotalAmount == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Total amount is not correct", "System Message", new[] { DialogResult.OK },
                FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
            if (txtPayAmount == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Payable amount is nor correct", "System Message", new[] { DialogResult.OK },
                        FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
            if (gridView1.RowCount >= 1)
            {
                List<SellesChild> sellsChild = new List<SellesChild>();

                SellsParent sellsParent = new SellsParent()
                {
                    SellsInvoice = txtInvoiceNo.EditValue.ToString(),
                    SellsDate = Convert.ToDateTime(txtDate.EditValue),
                    SalesMonth = Convert.ToDateTime(txtDate.EditValue).ToString("yyyyMM"),
                    CustomerName = Convert.ToInt32(cmbCustomerName.EditValue),
                    ContactNo = (string)txtMobileNo.EditValue,
                    TotalAmount = Convert.ToInt32(txtTotalAmount.EditValue),
                    PayAmount = Convert.ToInt32(txtPayAmount.EditValue),
                    ReturnAmount = Convert.ToInt32(txtReturnAmount.EditValue),
                    DueAmount = Convert.ToInt32(txtDueAmount.EditValue),
                    SellsBy = txtUserName.EditValue.ToString(),
                    PcName = txtComputerName.EditValue.ToString(),
                };
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    sellsChild.Add(new SellesChild()
                    {
                        SellsInvoice = txtInvoiceNo.EditValue.ToString(),
                        ProductCode = gridView1.GetRowCellValue(i, "ProductCode").ToString(),
                        Name = gridView1.GetRowCellValue(i, "Name").ToString(),
                        ColurId = gridView1.GetRowCellValue(i, "ColurId") == null ? null : gridView1.GetRowCellValue(i, "ColurId").ToString(),
                        SizeId = gridView1.GetRowCellValue(i, "SizeId") == null ? null : gridView1.GetRowCellValue(i, "SizeId").ToString(),
                        BrandId = gridView1.GetRowCellValue(i, "BrandId") == null ? null : gridView1.GetRowCellValue(i, "BrandId").ToString(),
                        Qty = Convert.ToInt16(gridView1.GetRowCellValue(i, "Qty")),
                        SellingPrice = Convert.ToInt16(gridView1.GetRowCellValue(i, "SellingPrice")),
                        VatPercent = Convert.ToInt32(gridView1.GetRowCellValue(i, "VatPercent") == null ? 0 : gridView1.GetRowCellValue(i, "VatPercent")),
                        VatAmount = Convert.ToInt16(gridView1.GetRowCellValue(i, "VatAmount") == null ? 0 : gridView1.GetRowCellValue(i, "VatAmount")),
                        DisCountPercent = Convert.ToDecimal(gridView1.GetRowCellValue(i, "DisCountPercent") == null ? 0 : gridView1.GetRowCellValue(i, "DisCountPercent")),
                        DiscountAmount = Convert.ToInt16(gridView1.GetRowCellValue(i, "DiscountAmount") == null ? 0 : gridView1.GetRowCellValue(i, "DiscountAmount")),
                        TotalAmount = Convert.ToInt32(gridView1.GetRowCellValue(i, "TotalAmount") == null ? 0 : gridView1.GetRowCellValue(i, "TotalAmount")),
                        PayAmount = Convert.ToInt32(txtPayAmount.EditValue),
                        ReturnAmount = Convert.ToInt16(txtReturnAmount.EditValue),
                        SellsBy = sellsParent.SellsBy,
                        SalesMonth = Convert.ToDateTime(txtDate.EditValue).ToString("yyyyMM")
                    });
                }
                _sellsRepository.InsertSellsParent(sellsParent);
                _sellsRepository.InsertSellsChild(sellsChild);

                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Sells save successfully", "System Message", new[] { DialogResult.OK },
                      FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationBlue()));
                string invoice = txtInvoiceNo.EditValue.ToString();

                txtInvoiceNo.EditValue = _getByAllSequence.GetByAll().Where(f => f.Code == "SInvoice").FirstOrDefault().StartWith;

                //ReportViewer openForm = new ReportViewer("Report_4", Command.SettingValue.NotApplicable.ToString())
                //{
                //    KeyFieldCode = invoice
                //};
                //openForm.ShowDialog();

                rptPosInvoice Report_1 = new rptPosInvoice()
                {
                    DataSource = sellsChild
                };
                Report_1.ShowPreview();
                Report_1.PrintDialog();
                ClearForm();
            }
            else
            {
                Voice.Speech("No sells found please try sells");
                Console.Beep(5000, 800);
                return;
            }
        }

        private void ClearForm()
        {
            txtTotalAmount.EditValue = null;
            txtPayAmount.EditValue = null;
            txtReturnAmount.EditValue = null;
            txtMobileNo.EditValue = null;
            txtCustomerDues.EditValue = 0;
            gridControl2.DataSource = _sellsRepository.GetByLastSells(txtDate.EditValue.ToString());
            gridControl1.DataSource = null;
            dataTable.Rows.Clear();
            dataTable.Clear();
        }

        private void TotalAmountByGrid()
        {
            int sum = 0;
            int qty = 0;
            for (int x = 0; x < gridView1.DataRowCount; x++)
            {
                sum += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["TotalAmount"]));
                qty += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["Qty"]));
                txtTotalAmount.EditValue = sum;
                txtTotalQty.EditValue = qty;
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridView1.UpdateTotalSummary();
            this.txtTotalAmount.EditValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, TotalAmount);
        }

        private void txtPayAmount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIsDue.Checked)
                {
                    int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue);
                    int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                    txtDueAmount.EditValue = totalAmount - payAmount;
                    txtReturnAmount.EditValue = 0;
                }
                else
                {
                    int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue);
                    int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                    txtReturnAmount.EditValue = payAmount - totalAmount;
                    txtDueAmount.EditValue = 0;
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Please input correct amount", "System Message", new[] { DialogResult.OK },
                FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
            gridView1.RefreshData();
            TotalAmountByGrid();
        }

        private void txtPayAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            btnSales.Focus();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            DbOperation();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnReInvoice_Click(object sender, EventArgs e)
        {
            if (txtReInvoice.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Please input a invoice number.", "System Message", new[] { DialogResult.OK },
               FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
            string invoice = txtReInvoice.EditValue.ToString();
            ReportViewer openForm = new ReportViewer("Report_4", Command.SettingValue.NotApplicable.ToString())
            {
                KeyFieldCode = invoice
            };
            openForm.ShowDialog();
        }

        private void cmbCustomerName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtMobileNo.EditValue = _custRepository.GetAllCustomer().Where(f => Convert.ToString(f.CustId) == cmbCustomerName.EditValue.ToString()).FirstOrDefault().ContactNo;
                txtCustomerDues.EditValue = _custRepository.GetAllCustomerArrear(cmbCustomerName.EditValue.ToString()).FirstOrDefault().DueAmount;
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message);
            }
        }

        private void chkIsDue_Click(object sender, EventArgs e)
        {
            if (chkIsDue.Checked)
            {
                int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue);
                int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                txtReturnAmount.EditValue = 0;
                txtDueAmount.EditValue = totalAmount - payAmount;
            }
            else
            {
                int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue);
                int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                txtReturnAmount.EditValue = payAmount - totalAmount;
                txtDueAmount.EditValue = 0;
            }
        }

        private void chkIsDue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsDue.Checked)
            {
                int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue);
                int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                txtReturnAmount.EditValue = 0;
                txtDueAmount.EditValue = totalAmount - payAmount;
            }
            else
            {
                int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue);
                int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                txtReturnAmount.EditValue = payAmount - totalAmount;
                txtDueAmount.EditValue = 0;
            }
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    frmCustomerEntry openForm = new frmCustomerEntry
                    {
                        dbAccess = Command.DbCommand.Create,
                    };
                    openForm.FormClosed += OpenForm_FormClosed;
                    openForm.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Smart Shop Alert!:- Data Error", "System Message" + exception.Message.ToString(), new[] { DialogResult.OK },
                   FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
            }
        }
        private void OpenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadCustomer();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            IEnumerable<Products> listOfProduct = _sellsRepository.GetByAllSellsProducts();
            if (txtProductCode.EditValue == null) return;
            txtProductCode.EditValue = listOfProduct.ToList();

        }
    }
}

