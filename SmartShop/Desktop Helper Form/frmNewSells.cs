using DevExpress.XtraEditors;
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
        IBaseRepository<ProductName> baseRepository = new ProductNameRepository();
        public List<SellesChild> SellesChild = new List<SellesChild>();
        SellsRepository _sellsRepository = new SellsRepository();
        ProductNameRepository productNameRepository = new ProductNameRepository();
        GetByAllSequence _getByAllSequence = new GetByAllSequence();
        IStockList<Stock> stock = new StockRepository();
        ICustRepository<CustomerInformation> _custRepository = new CustomersRepository();
        public frmNewSells()
        {
            InitializeComponent();
            layoutControl1.AllowCustomization = false;
        }

        private void frmNewSells_Load(object sender, EventArgs e)
        {
            //  SplashScreenManager.ShowForm(this, typeof(WaitForm1), useFadeIn: true, useFadeOut: true);
            LoadProduct();
            txtInvoiceNo.EditValue = DateTime.Now.ToString("yyyyMMdd") + _getByAllSequence.GetByAll().Where(f => f.Code == "SInvoice").FirstOrDefault().StartWith;
            txtUserName.EditValue = Settings.Default.UserName;
            txtComputerName.EditValue = System.Net.Dns.GetHostName();
            txtDate.EditValue = DateTime.Now.ToString("dd-MMM-yyyy");
            gridControl3.DataSource = _sellsRepository.GetByLastSells(txtDate.EditValue.ToString());
            LoadCustomer();
            
            // SplashScreenManager.CloseForm();
        }
        public void LoadCustomer()
        {
            cmbCustomerName.Properties.DataSource = _custRepository.GetAllCustomer();
            cmbCustomerName.Properties.DisplayMember = "CustomerName";
            cmbCustomerName.Properties.ValueMember = "CustId";
        }
        public void LoadProduct()
        {
            gridControl1.DataSource = productNameRepository.GetAllProductWithStock();
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
                txtTotalAmount.EditValue = sum;
                txtTotalQty.EditValue = qty;
                txtTotalVatAmount.EditValue = vat;
                txtTotalDisCountAmt.EditValue = dis;
                txtgTotalQty.EditValue = qty;
                txtgTotalAmount.EditValue = sum;
            }
            if (gridView2.DataRowCount <= 0)
            {
                txtTotalAmount.EditValue = 0;
                txtTotalQty.EditValue = 0;
                txtTotalVatAmount.EditValue = 0;
                txtTotalDisCountAmt.EditValue = 0;
                txtgTotalQty.EditValue = 0;
                txtgTotalAmount.EditValue = 0;
            }
        }
        private void layoutControlGroup2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Add Item")
            {
                int[] selectedRowHandles = gridView1.GetSelectedRows();
                foreach (int items in selectedRowHandles)
                {
                    var code = gridView1.GetRowCellValue(items, ProductCode).ToString();
                    IEnumerable<Stock> information = stock.GetByStockListProductCode(code);

                    if (!information.Any())
                    {
                        XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No available qty for this item", "System Message", new[] { DialogResult.OK },
                                           FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                        return;
                    }
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
                    int totalQty = information.FirstOrDefault().QtyBalance;
                    int Qty = Convert.ToInt32(txtQty.EditValue);
                    if (totalQty >= Qty)
                    {
                        txtStockQty.EditValue = totalQty;
                        if (!gridView1.IsGroupRow(items))
                        {
                            SellesChild.Add(new SellesChild()
                            {
                                SellsInvoice = txtInvoiceNo.EditValue.ToString(),
                                ProductCode = gridView1.GetRowCellValue(items, ProductCode).ToString(),
                                Qty = Convert.ToInt16(txtQty.EditValue),
                                SalesMonth = Convert.ToDateTime(txtDate.EditValue).ToString("yyyyMM"),
                                Name = gridView1.GetRowCellValue(items, Name).ToString(),
                                ColurId = gridView1.GetRowCellValue(items, ColurId).ToString(),
                                BrandId = gridView1.GetRowCellValue(items, BrandId).ToString(),
                                SizeId = gridView1.GetRowCellValue(items, SizeId).ToString(),
                                SellingPrice = Convert.ToInt32(gridView1.GetRowCellValue(items, SellingPrice)),
                                VatPercent = Convert.ToInt32(gridView1.GetRowCellValue(items, VatPercent)),
                                VatAmount = (Convert.ToInt32(gridView1.GetRowCellValue(items, SellingPrice)) * Convert.ToInt32(gridView1.GetRowCellValue(items, VatPercent) == null ? 0 : Convert.ToInt32(gridView1.GetRowCellValue(items, VatPercent)))) / 100,
                                DisCountPercent = gridView1.GetRowCellValue(items, DisCountPercent) == null ? 0 : Convert.ToDecimal(gridView1.GetRowCellValue(items, "DisCountPercent")),
                                DiscountAmount = (Convert.ToInt32(gridView1.GetRowCellValue(items, SellingPrice)) * (gridView1.GetRowCellValue(items, DisCountPercent) == null ? 0 : Convert.ToInt32(gridView1.GetRowCellValue(items, "DisCountPercent")))) / 100,
                                TotalAmount = (Convert.ToInt32(gridView1.GetRowCellValue(items, SellingPrice)) * Convert.ToInt32(txtQty.EditValue)
                                           + (Convert.ToInt32(gridView1.GetRowCellValue(items, SellingPrice)) * Convert.ToInt32(gridView1.GetRowCellValue(items, VatPercent) == null ? 0 : Convert.ToInt32(gridView1.GetRowCellValue(items, VatPercent)))) / 100)
                                           - (Convert.ToInt32(gridView1.GetRowCellValue(items, SellingPrice)) * Convert.ToInt32(gridView1.GetRowCellValue(items, DisCountPercent) == null ? 0 : Convert.ToInt32(gridView1.GetRowCellValue(items, DisCountPercent)))) / 100
                            });

                            gridControl1.RefreshDataSource();
                            gridView1.OptionsSelection.MultiSelect = false;
                        }
                        gridControl2.RefreshDataSource();
                        gridView1.OptionsSelection.MultiSelect = true;
                        gridControl2.DataSource = SellesChild;
                        TotalAmountByGrid();
                    }
                    else
                    {
                        XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No available qty for this item", "System Message", new[] { DialogResult.OK },
                          FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                        return;
                    }
                }
            }
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
                else if (gridView2.RowCount == null)
                {
                    gridView2.DeleteSelectedRows();
                    gridView2.RefreshData();
                    TotalAmountByGrid();
                }
            }
            if (e.Button.Properties.Caption == "Refresh")
            {
                LoadProduct();
            }
        }
        private void btnSales_Click(object sender, EventArgs e)
        {
            DbOperation();
            LoadProduct();
        }
        private void txtPayAmount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIsDue.Checked)
                {
                    int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                    int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue) - Convert.ToInt32(txtSpecialDiscount.EditValue);
                    txtDueAmount.EditValue = totalAmount - payAmount;
                    txtReturnAmount.EditValue = 0;
                }
                else
                {
                    int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                    int specialDiscount = Convert.ToInt32(txtSpecialDiscount.EditValue);
                    int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue) -Convert.ToInt32(txtSpecialDiscount.EditValue);
                    txtReturnAmount.EditValue = payAmount-totalAmount;
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
                int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue) - Convert.ToInt32(txtSpecialDiscount.EditValue);
                txtDueAmount.EditValue = totalAmount - payAmount;
                txtReturnAmount.EditValue = 0;
            }
            else
            {
                int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                int specialDiscount = Convert.ToInt32(txtSpecialDiscount.EditValue);
                int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue) - Convert.ToInt32(txtSpecialDiscount.EditValue);
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
            if (txtTotalAmount.EditValue == null)
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
                        TotalAmount = Convert.ToInt32(txtTotalAmount.EditValue),
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
                XtraMessageBox.Show("Smart Shop Alert!:- Data Error", exception.Message);
            }
        }
        private void OpenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadCustomer();
        }
        private void chkIsDue_EditValueChanged(object sender, EventArgs e)
        {
            if (chkIsDue.Checked)
            {
                int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue) - Convert.ToInt32(txtSpecialDiscount.EditValue);
                txtDueAmount.EditValue = totalAmount - payAmount;
                txtReturnAmount.EditValue = 0;
            }
            else
            {
                int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                int specialDiscount = Convert.ToInt32(txtSpecialDiscount.EditValue);
                int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue) - Convert.ToInt32(txtSpecialDiscount.EditValue);
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

            ReportViewer openForm = new ReportViewer("Report_8", Command.SettingValue.NotApplicable.ToString())
            {
                KeyFieldCode = invoice
            };
            openForm.ShowDialog();
        }
        private void Clear()
        {
            gridControl2.DataSource = null;
            txtDueAmount.EditValue = 0;
            txtPayAmount.EditValue = 0;
            txtTotalVatAmount.EditValue = 0;
            txtLastDue.EditValue = 0;
            txtReturnAmount.EditValue = 0;
            txtTotalAmount.EditValue = 0;
            txtgTotalAmount.EditValue = 0;
            txtgTotalQty.EditValue = 0;
            txtTotalQty.EditValue = 0;
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
                int vatAmount = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["VatAmount"]));
                int disCountAmount = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["DiscountAmount"]));
                int totalAmount = ((qty * sellingPrice) + vatAmount) - disCountAmount;
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "TotalAmount", totalAmount);

                TotalAmountByGrid();
            }

            if (e.Column.FieldName == "Qty")
            {
                int qty = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["Qty"]));
                int sellingPrice = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["SellingPrice"]));
                int vatAmount = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["VatAmount"]));
                int disCountAmount = Convert.ToInt32(gridView2.GetListSourceRowCellValue(e.RowHandle, gridView2.Columns["DiscountAmount"]));
                int totalAmount = ((qty * sellingPrice) + vatAmount) - disCountAmount;
                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "TotalAmount", totalAmount);

                TotalAmountByGrid();
            }
        }
    }
}