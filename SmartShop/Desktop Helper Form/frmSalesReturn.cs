using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Windows.Forms;
using static SmartShop.Interface.ISalesReturn;
using System.Linq;
using SmartShop.Properties;
using System.Collections.Generic;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmSalesReturn : DevExpress.XtraEditors.XtraForm
    {
        public List<SalesReturn> salesReturns = new List<SalesReturn>();
        IReturn<SalesReturn> salesReturn = new SalesReturnRepository();
        SalesReturnRepository salesReturnRepository = new SalesReturnRepository();

        public frmSalesReturn()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            gridControl1.DataSource = null;
            gridView1.RefreshData();
            var list = salesReturn.GetByInvoice(txtInvoiceNo.EditValue.ToString());
            if (list.Any())
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = salesReturn.GetByInvoice(txtInvoiceNo.EditValue.ToString());
            }
            else
            {
                gridControl1.DataSource = null;
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No return found", "System Message", new[] { DialogResult.OK },
                    FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));

                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbOperation();
        }
        private void TotalSummary()
        {
            int sum = 0;
            int qty = 0;
            int[] rowHandle = gridView1.GetSelectedRows();
            foreach (var x in rowHandle)
            {
                sum += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["TotalAmount"]));
                qty += Convert.ToInt32(gridView1.GetListSourceRowCellValue(x, gridView1.Columns["Qty"]));
                txtTotalAmount.EditValue = sum;
                txtQty.EditValue = qty;
            }
        }

        private void DbOperation()
        {
            var list = salesReturn.GetByReturnInvoice(txtInvoiceNo.EditValue.ToString());
            int[] selectedRowHandles = gridView1.GetSelectedRows();
            foreach (var items in selectedRowHandles)
            {
                if (!list.Any())
                {
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No item to return.", "System Message", new[] { DialogResult.OK },
                       FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                    return;
                }
                else
                {
                    var code = list.FirstOrDefault().ProductCode.ToString();
                    if (code != null)
                    {
                        XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, $@"Already return {code}", "System Message", new[] { DialogResult.OK },
                        FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                        return;
                    }
                    salesReturns.Add(new SalesReturn()
                    {
                        SellsDate = Convert.ToDateTime(gridView1.GetRowCellValue(items, SellsDate)),
                        SalesMonth = Convert.ToDateTime(gridView1.GetRowCellValue(items, SellsDate)).ToString("yyyyMM"),
                        SellsInvoice = txtInvoiceNo.EditValue.ToString(),
                        ProductCode = gridView1.GetRowCellValue(items, ProductCode).ToString(),
                        Qty = Convert.ToInt32(gridView1.GetRowCellValue(items, Qty)),
                        SellingPrice = Convert.ToInt32(gridView1.GetRowCellValue(items, SellingPrice)),
                        TotalAmount = Convert.ToInt32(gridView1.GetRowCellValue(items, TotalAmount)),
                        SellsBy = Settings.Default.LoginName,
                        PcName = System.Environment.MachineName
                    });
                }

                TotalSummary();
            }
            salesReturnRepository.InsertSalesReturn(salesReturns);
            gridControl1.DataSource = null;
            gridView1.RefreshData();
            XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Return has been successfully", "System Message", new[] { DialogResult.OK },
                        FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));

            return;
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            TotalSummary(); ;
        }
    }
}