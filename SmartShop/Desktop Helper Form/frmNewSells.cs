using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using SmartShop.SmartReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.CustomerInfoInterface;
using static SmartShop.Interface.Interface;
using static SmartShop.Interface.StockList;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmNewSells : DevExpress.XtraEditors.XtraForm
    {
        IBaseRepository<Products> baseRepository = new ProductNameRepository();
        public List<SellesChild> SellesChild = new List<SellesChild>();
        SellsRepository _sellsRepository = new SellsRepository();
        ProductNameRepository productNameRepository = new ProductNameRepository();
        GetByAllSequence _getByAllSequence = new GetByAllSequence();
        IStockList<Stock> stock = new StockRepository();
        ICustRepository<CustomerInformation> _custRepository = new CustomersRepository();
        public frmNewSells()
        {
            InitializeComponent();
        }

        private void frmNewSells_Load(object sender, EventArgs e)
        {
            repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            gridView2.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;

            LoadProducts();
            txtInvoiceNo.EditValue = DateTime.Now.ToString("yyyyMMdd") + _getByAllSequence.GetByAll().Where(f => f.Code == "SInvoice").FirstOrDefault().StartWith;
            txtUserName.EditValue = Settings.Default.UserName;
            txtComputerName.EditValue = System.Net.Dns.GetHostName();
            txtDate.EditValue = DateTime.Now.ToString("dd-MMM-yyyy");
            gridControl3.DataSource = _sellsRepository.GetByLastSells(txtDate.EditValue.ToString());
            LoadCustomer();
        }
        public void LoadCustomer()
        {
            cmbCustomerName.Properties.DataSource = _custRepository.GetAllCustomer();
            cmbCustomerName.Properties.DisplayMember = "CustomerName";
            cmbCustomerName.Properties.ValueMember = "CustId";
        }
        private void LoadProducts()
        {
            cmbProducts.Properties.DataSource = productNameRepository.GetAllProduct().ToList();
            cmbProducts.Properties.DisplayMember = "ProductName";
            cmbProducts.Properties.ValueMember = "ProductCode";
        }
        private void TotalAmountByGrid()
        {
            int sum = 0;
            int qty = 0;
            int vat = 0;
            int dis = 0;
            for (int x = 0; x < gridView2.DataRowCount; x++)
            {
                sum += Convert.ToInt32(gridView2.GetListSourceRowCellValue(x, gridView2.Columns["TotalAmount"]));
                qty += Convert.ToInt32(gridView2.GetListSourceRowCellValue(x, gridView2.Columns["Qty"]));
                vat += Convert.ToInt32(gridView2.GetListSourceRowCellValue(x, gridView2.Columns["VatAmount"]));
                dis += Convert.ToInt32(gridView2.GetListSourceRowCellValue(x, gridView2.Columns["DiscountAmount"]));
                txtgTotalAmount.EditValue = sum;
                txtgTotalQty.EditValue = qty;
                txtgTotalQty.EditValue = qty;
                txtgTotalAmount.EditValue = sum;
            }
            if (gridView2.DataRowCount <= 0)
            {
                txtgTotalAmount.EditValue = 0;
                txtgTotalQty.EditValue = 0;
                txtgTotalQty.EditValue = 0;
                txtgTotalAmount.EditValue = 0;
            }
        }
        private void layoutControlGroup2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Delete")
            {
                gridView2.DeleteSelectedRows();
                gridView2.RefreshData();
                TotalAmountByGrid();

                if (gridView2.RowCount <= 0)
                {
                    gridView2.DeleteSelectedRows();
                    gridView2.RefreshData();
                    TotalAmountByGrid();
                }
                else
                {
                    gridView2.DeleteSelectedRows();
                    gridView2.RefreshData();
                    TotalAmountByGrid();
                }
            }
            if (e.Button.Properties.Caption == "Refresh")
            {
                //LoadProduct();
            }
        }
        private void btnSales_Click(object sender, EventArgs e)
        {
            DbOperation();
            //LoadProduct();
        }
        private void txtPayAmount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIsDue.Checked)
                {
                    int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                    int totalAmount = Convert.ToInt32(txtgTotalAmount.EditValue) - Convert.ToInt32(txtSpecialDiscount.EditValue);
                    txtDueAmount.EditValue = totalAmount - payAmount;
                    txtReturnAmount.EditValue = 0;
                }
                else
                {
                    int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                    int specialDiscount = Convert.ToInt32(txtSpecialDiscount.EditValue);
                    int totalAmount = Convert.ToInt32(txtgTotalAmount.EditValue) - Convert.ToInt32(txtSpecialDiscount.EditValue);
                    txtReturnAmount.EditValue = payAmount - totalAmount;
                    txtDueAmount.EditValue = 0;
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Please input correct amount");
            }
        }
        private void chkIsDue_Click(object sender, EventArgs e)
        {
            if (chkIsDue.Checked)
            {
                int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                int totalAmount = Convert.ToInt32(txtgTotalAmount.EditValue) - Convert.ToInt32(txtSpecialDiscount.EditValue);
                txtDueAmount.EditValue = totalAmount - payAmount;
                txtReturnAmount.EditValue = 0;
            }
            else
            {
                int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                int specialDiscount = Convert.ToInt32(txtSpecialDiscount.EditValue);
                int totalAmount = Convert.ToInt32(txtgTotalAmount.EditValue) - Convert.ToInt32(txtSpecialDiscount.EditValue);
                txtReturnAmount.EditValue = payAmount - totalAmount;
                txtDueAmount.EditValue = 0;
            }
        }
        private void cmbCustomerName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtContactNo.EditValue = _custRepository.GetAllCustomer().Where(f => Convert.ToString(f.CustId) == cmbCustomerName.EditValue.ToString()).FirstOrDefault().ContactNo;
                txtLastDue.EditValue = _custRepository.GetAllCustomerArrear(cmbCustomerName.EditValue.ToString()).FirstOrDefault().DueAmount;
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message);
            }
        }
        private void DbOperation()
        {
            int returnAmount = Convert.ToInt16(txtReturnAmount.EditValue);
            if (returnAmount < 0)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Pay Amount is less then total amount", "System Message", new[] { DialogResult.OK },
                FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
            if (txtgTotalAmount.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Total amount is nor correct", "System Message", new[] { DialogResult.OK },
                FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
            if (txtPayAmount.EditValue == null || Convert.ToInt32(txtPayAmount.EditValue) == 0)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Payable amount is nor correct", "System Message", new[] { DialogResult.OK },
               FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
            if (chkIsDue.Checked && cmbCustomerName.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Definitely added customer name", "System Message", new[] { DialogResult.OK },
                       FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
            try
            {
                if (gridView2.RowCount >= 1)
                {
                    List<SellesChild> sellsChild = new List<SellesChild>();

                    SellsParent sellsParent = new SellsParent()
                    {
                        SellsInvoice = txtInvoiceNo.EditValue.ToString(),
                        SellsDate = Convert.ToDateTime(txtDate.EditValue),
                        SalesMonth = Convert.ToDateTime(txtDate.EditValue).ToString("yyyyMM"),
                        CustomerName = Convert.ToInt32(cmbCustomerName.EditValue),
                        ContactNo = (string)txtContactNo.EditValue,
                        TotalAmount = Convert.ToInt32(txtgTotalAmount.EditValue),
                        PayAmount = Convert.ToInt32(txtPayAmount.EditValue),
                        ReturnAmount = Convert.ToInt32(txtReturnAmount.EditValue),
                        DueAmount = Convert.ToInt32(txtDueAmount.EditValue),
                        SellsBy = txtUserName.EditValue.ToString(),
                        PcName = txtComputerName.EditValue.ToString()
                    };

                    for (int i = 0; i < gridView2.DataRowCount; i++)
                    {
                        sellsChild.Add(new SellesChild()
                        {
                            SellsInvoice = txtInvoiceNo.EditValue.ToString(),
                            ProductCode = gridView2.GetRowCellValue(i, "ProductCode").ToString(),
                            Name = gridView2.GetRowCellValue(i, "Name").ToString(),
                            ColurId = gridView2.GetRowCellValue(i, "ColurId") == null ? null : gridView2.GetRowCellValue(i, "ColurId").ToString(),
                            SizeId = gridView2.GetRowCellValue(i, "SizeId") == null ? null : gridView2.GetRowCellValue(i, "SizeId").ToString(),
                            BrandId = gridView2.GetRowCellValue(i, "BrandId") == null ? null : gridView2.GetRowCellValue(i, "BrandId").ToString(),
                            Qty = Convert.ToInt16(gridView2.GetRowCellValue(i, "Qty")),
                            SellingPrice = Convert.ToInt32(gridView2.GetRowCellValue(i, "SellingPrice")),
                            VatPercent = Convert.ToInt32(gridView2.GetRowCellValue(i, "VatPercent") == null ? 0 : gridView2.GetRowCellValue(i, "VatPercent")),
                            VatAmount = Convert.ToInt16(gridView2.GetRowCellValue(i, "VatAmount") == null ? 0 : gridView2.GetRowCellValue(i, "VatAmount")),
                            DisCountPercent = Convert.ToDecimal(gridView2.GetRowCellValue(i, "DisCountPercent") == null ? 0 : gridView2.GetRowCellValue(i, "DisCountPercent")),
                            DiscountAmount = Convert.ToInt32(gridView2.GetRowCellValue(i, "DiscountAmount") == null ? 0 : gridView2.GetRowCellValue(i, "DiscountAmount")),
                            TotalAmount = Convert.ToInt32(gridView2.GetRowCellValue(i, "TotalAmount") == null ? 0 : gridView2.GetRowCellValue(i, "TotalAmount")),
                            PayAmount = Convert.ToInt32(txtPayAmount.EditValue),
                            ReturnAmount = Convert.ToInt32(txtReturnAmount.EditValue),
                            SellsBy = txtUserName.EditValue.ToString(),
                            SellsDate = Convert.ToDateTime(txtDate.EditValue),
                            SalesMonth = Convert.ToDateTime(txtDate.EditValue).ToString("yyyyMM")
                        });
                    }
                    _sellsRepository.InsertSellsParent(sellsParent);
                    _sellsRepository.InsertSellsChild(sellsChild);

                    Clear();

                    string invoice = txtInvoiceNo.EditValue.ToString();

                    txtInvoiceNo.EditValue = DateTime.Now.ToString("yyyyMMdd") + _getByAllSequence.GetByAll().Where(f => f.Code == "SInvoice").FirstOrDefault().StartWith;
                    gridControl3.DataSource = _sellsRepository.GetByLastSells(txtDate.EditValue.ToString());

                    if (!IsPrintable.Checked) return;
                    else
                        if (isChk.Checked)
                    {
                        rptPosInvoice Report_1 = new rptPosInvoice()
                        {
                            DataSource = sellsChild
                        };
                        Report_1.ShowPreview();
                        Report_1.PrintDialog();
                        Report_1.Print();
                        sellsChild.Clear();
                        SellesChild.Clear();
                    }
                    else
                    {
                        ReportViewer openForm = new ReportViewer("Report_8", Command.SettingValue.NotApplicable.ToString())
                        {
                            KeyFieldCode = invoice
                        };
                        openForm.ShowDialog();
                        sellsChild.Clear();
                        SellesChild.Clear();
                    }
                }
                else
                {
                    Voice.Speech("No sells found please try sells");
                    Console.Beep(5000, 800);
                    return;
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message.ToString());
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
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "System Error Message", exception.Message, new[] { DialogResult.OK },
                                FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
        }
        private void OpenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadCustomer();
            LoadProducts();
        }
        private void chkIsDue_EditValueChanged(object sender, EventArgs e)
        {
            if (chkIsDue.Checked)
            {
                int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                int totalAmount = Convert.ToInt32(txtgTotalAmount.EditValue) - Convert.ToInt32(txtSpecialDiscount.EditValue);
                txtDueAmount.EditValue = totalAmount - payAmount;
                txtReturnAmount.EditValue = 0;
            }
            else
            {
                int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                int specialDiscount = Convert.ToInt32(txtSpecialDiscount.EditValue);
                int totalAmount = Convert.ToInt32(txtgTotalAmount.EditValue) - Convert.ToInt32(txtSpecialDiscount.EditValue);
                txtReturnAmount.EditValue = payAmount - totalAmount;
                txtDueAmount.EditValue = 0;
            }
        }
        private void btnReInvoicePrint_Click(object sender, EventArgs e)
        {
            if (txtReInvoice.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Please input a invoice number.", "System Message", new[] { DialogResult.OK },
                 FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
            string invoice = txtReInvoice.EditValue.ToString();
            var Invoice = _sellsRepository.All(invoice);
            if (!Invoice.Any())
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No Invoice Found", "System Message", new[] { DialogResult.OK },
                                 FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            };

            DialogResult result = XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Are you want to see A4 size invoice then press Yes. or see POS No.?", "Smart Shop Alert! *?", new[] { DialogResult.Yes, DialogResult.No },
                FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationBlue()));
            if (result == DialogResult.Yes)
            {
                ReportViewer openForm = new ReportViewer("Report_8", Command.SettingValue.NotApplicable.ToString())
                {
                    KeyFieldCode = invoice
                };
                openForm.ShowDialog();
            }
            else if (result == DialogResult.No)
            {
                //List<SellesChild> invoicebySales = new List<SellesChild>();
                //foreach (var item in Invoice)
                //{
                //    invoicebySales.Add(new SellesChild() {
                //        SellsInvoice = txtReInvoice.EditValue.ToString(),
                //        ProductCode = item.,
                //        Name = gridView2.GetRowCellValue(i, "Name").ToString(),
                //        ColurId = gridView2.GetRowCellValue(i, "ColurId") == null ? null : gridView2.GetRowCellValue(i, "ColurId").ToString(),
                //        SizeId = gridView2.GetRowCellValue(i, "SizeId") == null ? null : gridView2.GetRowCellValue(i, "SizeId").ToString(),
                //        BrandId = gridView2.GetRowCellValue(i, "BrandId") == null ? null : gridView2.GetRowCellValue(i, "BrandId").ToString(),
                //        Qty = Convert.ToInt16(gridView2.GetRowCellValue(i, "Qty")),
                //        SellingPrice = Convert.ToInt32(gridView2.GetRowCellValue(i, "SellingPrice")),
                //        VatPercent = Convert.ToInt32(gridView2.GetRowCellValue(i, "VatPercent") == null ? 0 : gridView2.GetRowCellValue(i, "VatPercent")),
                //        VatAmount = Convert.ToInt16(gridView2.GetRowCellValue(i, "VatAmount") == null ? 0 : gridView2.GetRowCellValue(i, "VatAmount")),
                //        DisCountPercent = Convert.ToDecimal(gridView2.GetRowCellValue(i, "DisCountPercent") == null ? 0 : gridView2.GetRowCellValue(i, "DisCountPercent")),
                //        DiscountAmount = Convert.ToInt32(gridView2.GetRowCellValue(i, "DiscountAmount") == null ? 0 : gridView2.GetRowCellValue(i, "DiscountAmount")),
                //        TotalAmount = Convert.ToInt32(gridView2.GetRowCellValue(i, "TotalAmount") == null ? 0 : gridView2.GetRowCellValue(i, "TotalAmount")),
                //        PayAmount = Convert.ToInt32(txtPayAmount.EditValue),
                //        ReturnAmount = Convert.ToInt32(txtReturnAmount.EditValue),
                //        SellsBy = txtUserName.EditValue.ToString(),
                //        SellsDate = Convert.ToDateTime(txtDate.EditValue),
                //        SalesMonth = Convert.ToDateTime(txtDate.EditValue).ToString("yyyyMM")
                //    });
                //}
                //rptPosInvoice Report_1 = new rptPosInvoice()
                //{
                //    DataSource = sellsChild
                //};
            }
        }
        private void Clear()
        {
            gridControl2.DataSource = null;
            txtDueAmount.EditValue = 0;
            txtPayAmount.EditValue = 0;
            txtLastDue.EditValue = 0;
            txtReturnAmount.EditValue = 0;
            txtgTotalAmount.EditValue = 0;
            txtgTotalQty.EditValue = 0;
            txtDueAmount.EditValue = 0;
            txtSpecialDiscount.EditValue = 0;
            txtQty.EditValue = 1;
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SellingPrice")
            {
                int qty = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["Qty"]));
                int sellingPrice = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["SellingPrice"]));
                int vatPercent = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["VatPercent"]));
                int disPercent = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["DisCountPercent"]));
                int vatAmount = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["VatAmount"]));
                int disCountAmount = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["DiscountAmount"]));
                int totalAmount = ((qty * sellingPrice) + vatAmount) - disCountAmount;
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "TotalAmount", totalAmount);
                int totalVatAmount = ((qty * sellingPrice) * vatPercent) / 100;
                int totalDisAmount = ((qty * sellingPrice) * disPercent) / 100;
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "VatAmount", totalVatAmount);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "DiscountAmount", totalDisAmount);

                TotalAmountByGrid();
            }

            if (e.Column.FieldName == "Qty")
            {
                int qty = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["Qty"]));
                int sellingPrice = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["SellingPrice"]));
                int vatPercent = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["VatPercent"]));
                int disPercent = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["DisCountPercent"]));
                int vatAmount = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["VatAmount"]));
                int disCountAmount = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["DiscountAmount"]));
                int totalAmount = ((qty * sellingPrice) + vatAmount) - disCountAmount;
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "TotalAmount", totalAmount);
                int totalVatAmount = ((qty * sellingPrice) * vatPercent) / 100;
                int totalDisAmount = ((qty * sellingPrice) * disPercent) / 100;
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "VatAmount", totalVatAmount);
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "DiscountAmount", totalDisAmount);

                TotalAmountByGrid();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    frmSalesReturn openForm = new frmSalesReturn();
                    openForm.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "System Error Message", exception.Message, new[] { DialogResult.OK },
                                 FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
        }

        private void btnItemAdded_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    frmProductNameEntry openForm = new frmProductNameEntry();
                    openForm.FormClosed += OpenForm_FormClosed;
                    openForm.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "System Error Message", exception.Message, new[] { DialogResult.OK },
                                 FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
        }

        private void btnViewStock_Click(object sender, EventArgs e)
        {
            try
            {
                var a = stock.GetAllStockList().ToList();

                {
                    frmGridStock frmStockList = new frmGridStock();

                    frmStockList.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "System Error Message", exception.Message, new[] { DialogResult.OK },
                                 FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
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
            IEnumerable<Products> products = productNameRepository.GetByAll(Convert.ToString(cmbProducts.EditValue.ToString()));
            if (products.Any())
            {
                IEnumerable<Stock> information = stock.GetByStockListProductCode(cmbProducts.EditValue.ToString());
                if (information.Any())
                {
                    int totalQty = information.FirstOrDefault().QtyBalance;
                    txtStockQty.EditValue = totalQty;
                    txtQty.Focus();
                    txtQty.SelectAll();
                }
                else
                {
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "System Error Message", "Stock not avaiable", new[] { DialogResult.OK },
                                 FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No product item here...please check product code.", "System Message", new[] { DialogResult.OK }, FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            IEnumerable<Stock> information = stock.GetByStockListProductCode(cmbProducts.EditValue.ToString());

            if (!information.Any())
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
            }
            if (information.FirstOrDefault().QtyBalance == 0)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No available qty for this item", "System Message", new[] { DialogResult.OK },
                           FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            };
            int totalQty = information.FirstOrDefault().QtyBalance;
            int Qty = Convert.ToInt32(txtQty.EditValue);
            if (totalQty >= Qty)
            {
                IEnumerable<Products> products = productNameRepository.GetByAll(Convert.ToString(cmbProducts.EditValue.ToString()));
                int sellingPrice = 0;
                int vatPercent = 0;
                int disPercent = 0;
                sellingPrice = Convert.ToInt32(products.FirstOrDefault().SellingPrice);
                vatPercent = Convert.ToInt32(products.FirstOrDefault().VatPercent);
                disPercent = Convert.ToInt32(products.FirstOrDefault().DisCountPercent);
                txtStockQty.EditValue = totalQty;
                if (products.Any())
                {
                    if (SellesChild.Any())
                    {
                        var checkReUse = SellesChild.Where(x => x.ProductCode == cmbProducts.EditValue.ToString()).FirstOrDefault();
                        if (checkReUse != null)
                        {
                            checkReUse.Qty = checkReUse.Qty + Convert.ToInt32(txtQty.EditValue);
                            checkReUse.TotalAmount = (checkReUse.Qty * checkReUse.SellingPrice);
                            checkReUse.VatAmount = checkReUse.VatAmount + (Convert.ToInt32(txtQty.EditValue) * checkReUse.SellingPrice) * vatPercent / 100;
                            checkReUse.DiscountAmount = checkReUse.DiscountAmount + (Convert.ToInt32(txtQty.EditValue) * checkReUse.SellingPrice) * disPercent / 100;
                            gridControl2.Refresh();
                            gridView2.RefreshData();
                        }
                        else
                        {
                            SellesChild.Add(new SellesChild()
                            {
                                SellsInvoice = txtInvoiceNo.EditValue.ToString(),
                                ProductCode = cmbProducts.EditValue.ToString(),
                                Qty = Convert.ToInt16(txtQty.EditValue),
                                SalesMonth = Convert.ToDateTime(txtDate.EditValue).ToString("yyyyMM"),
                                Name = products.FirstOrDefault().ProductName.ToString(),
                                SellingPrice = sellingPrice,
                                VatPercent = vatPercent,
                                VatAmount = (sellingPrice * vatPercent) == 0 ? 0 : (sellingPrice * Convert.ToInt32(txtQty.EditValue) * vatPercent / 100),
                                DisCountPercent = disPercent,
                                DiscountAmount = (sellingPrice * disPercent) == 0 ? 0 : (sellingPrice * Convert.ToInt32(txtQty.EditValue) * disPercent / 100),
                                TotalAmount = (sellingPrice * Convert.ToInt32(txtQty.EditValue) + (sellingPrice * Convert.ToInt32(txtQty.EditValue) * vatPercent / 100))
                                - (sellingPrice * Convert.ToInt32(txtQty.EditValue) * disPercent / 100),
                                BrandId = products.FirstOrDefault().BrandId.ToString() == null ? null : products.FirstOrDefault().BrandId.ToString(),
                                ColurId = products.FirstOrDefault().ColurId.ToString() == null ? null : products.FirstOrDefault().ColurId.ToString(),
                                SizeId = products.FirstOrDefault().SizeId.ToString() == null ? null : products.FirstOrDefault().SizeId.ToString(),
                            });

                            gridControl2.RefreshDataSource();
                            gridControl2.DataSource = SellesChild;
                            TotalAmountByGrid();
                            gridView2.OptionsSelection.MultiSelect = false;
                        }

                    }
                    else
                    {
                        SellesChild.Add(new SellesChild()
                        {
                            SellsInvoice = txtInvoiceNo.EditValue.ToString(),
                            ProductCode = cmbProducts.EditValue.ToString(),
                            Qty = Convert.ToInt16(txtQty.EditValue),
                            SalesMonth = Convert.ToDateTime(txtDate.EditValue).ToString("yyyyMM"),
                            Name = products.FirstOrDefault().ProductName.ToString(),
                            SellingPrice = sellingPrice,
                            VatPercent = vatPercent,
                            VatAmount = (sellingPrice * vatPercent) == 0 ? 0 : (sellingPrice * Convert.ToInt32(txtQty.EditValue) * vatPercent / 100),
                            DisCountPercent = disPercent,
                            DiscountAmount = (sellingPrice * disPercent) == 0 ? 0 : (sellingPrice * Convert.ToInt32(txtQty.EditValue) * disPercent / 100),
                            TotalAmount = (sellingPrice * Convert.ToInt32(txtQty.EditValue) + (sellingPrice * Convert.ToInt32(txtQty.EditValue) * vatPercent / 100))
                                - (sellingPrice * Convert.ToInt32(txtQty.EditValue) * disPercent / 100),
                            BrandId = products.FirstOrDefault().BrandId.ToString() == null ? null : products.FirstOrDefault().BrandId.ToString(),
                            ColurId = products.FirstOrDefault().ColurId.ToString() == null ? null : products.FirstOrDefault().ColurId.ToString(),
                            SizeId = products.FirstOrDefault().SizeId.ToString() == null ? null : products.FirstOrDefault().SizeId.ToString(),

                        });

                        gridControl2.RefreshDataSource();
                        gridControl2.DataSource = SellesChild;
                        TotalAmountByGrid();
                        gridView2.OptionsSelection.MultiSelect = false;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No available qty for this item", "System Message", new[] { DialogResult.OK },
                            FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;

            }
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            Console.Beep(5000, 800);
            if (XtraMessageBox.Show($"Are you want to delete this item {gridView2.GetRowCellValue(gridView2.FocusedRowHandle, base.Name) }?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var itemDelete = SellesChild.Where(x => x.ProductCode == gridView2.GetRowCellValue(gridView2.FocusedRowHandle, ProductCode).ToString()).FirstOrDefault();
                SellesChild.Remove(itemDelete);
                gridView2.DeleteSelectedRows();
                gridView2.RefreshData();
                TotalAmountByGrid();
            }
        }

        private void repositoryItemButtonEdit2_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            if (buttonIndex == 0)
            {
                int sum = 0;
                int qty = 0;
                int vat = 0;
                int dis = 0;
                int totQty = 0;

                int GridQtySum = 0;

                GridQtySum = Convert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, Qty));
                totQty = GridQtySum + 1;
                IEnumerable<Stock> qtyBalnce = stock.GetByStockListProductCode(cmbProducts.EditValue.ToString());
                if (qtyBalnce.FirstOrDefault().QtyBalance < totQty)
                {
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No available stock for this item", "System Message", new[] { DialogResult.OK },
                            FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                    return;
                }

                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "Qty", totQty);
                gridView2.RefreshData();
                for (int x = 0; x < gridView2.DataRowCount; x++)
                {
                    sum += Convert.ToInt32(gridView2.GetListSourceRowCellValue(x, gridView2.Columns["TotalAmount"]));
                    qty += Convert.ToInt32(gridView2.GetListSourceRowCellValue(x, gridView2.Columns["Qty"]));
                    vat += Convert.ToInt32(gridView2.GetListSourceRowCellValue(x, gridView2.Columns["VatAmount"]));
                    dis += Convert.ToInt32(gridView2.GetListSourceRowCellValue(x, gridView2.Columns["DiscountAmount"]));
                    gridView2.RefreshData();
                    txtgTotalAmount.EditValue = sum;
                    txtgTotalQty.EditValue = qty;
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

                GridQtySum = Convert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, Qty));
                totQty = GridQtySum - 1;
                IEnumerable<Stock> qtyBalnce = stock.GetByStockListProductCode(cmbProducts.EditValue.ToString());
                if (qtyBalnce.FirstOrDefault().QtyBalance < totQty)
                {
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No available stock for this item", "System Message", new[] { DialogResult.OK },
                            FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                    return;
                }
                if (totQty <= 0)
                {
                    totQty = 0;
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "TotalAmount", 0);
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "VatAmount", 0);
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "DiscountAmount", 0);
                }

                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "Qty", totQty);
                gridView2.RefreshData();

                for (int x = 0; x < gridView2.DataRowCount; x++)
                {
                    sum += Convert.ToInt32(gridView2.GetListSourceRowCellValue(x, gridView2.Columns["TotalAmount"]));
                    qty += Convert.ToInt32(gridView2.GetListSourceRowCellValue(x, gridView2.Columns["Qty"]));
                    vat += Convert.ToInt32(gridView2.GetListSourceRowCellValue(x, gridView2.Columns["VatAmount"]));
                    dis += Convert.ToInt32(gridView2.GetListSourceRowCellValue(x, gridView2.Columns["DiscountAmount"]));

                    gridView2.RefreshData();
                    txtgTotalAmount.EditValue = sum;
                    txtgTotalQty.EditValue = qty;
                }
                TotalAmountByGrid();
            }
        }
    }
}