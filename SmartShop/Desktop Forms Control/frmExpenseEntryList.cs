using DevExpress.XtraEditors;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Models;
using SmartShop.Repository;
using SmartShop.SmartReports;
using System;
using System.Windows.Forms;
using static SmartShop.Interface.IExpensesExecute;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmExpenseEntryList : DevExpress.XtraEditors.XtraForm
    {
        IExpensesEntry<ExpensesEntry> _expensesEntry = new ExpensesEntryRepository();
        public frmExpenseEntryList()
        {
            InitializeComponent();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                {
                    frmExpensesEntry openForm = new frmExpensesEntry
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
            gridControl1.DataSource = _expensesEntry.GetAllExpensesEntry(txtDateF.EditValue.ToString(), txtDateT.EditValue.ToString());
        }

        private void frmExpenseEntryList_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            txtDateF.EditValue = new DateTime(now.Year, now.Month, 1);
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            txtDateT.EditValue = endDate;
        }

        private void btnView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = _expensesEntry.GetAllExpensesEntry(txtDateF.EditValue.ToString(), txtDateT.EditValue.ToString());
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = _expensesEntry.GetAllExpensesEntry(txtDateF.EditValue.ToString(), txtDateT.EditValue.ToString());
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportViewer openForm = new ReportViewer("Report_14", Command.SettingValue.NotApplicable.ToString())
            {
                DateF = txtDateF.EditValue.ToString(),
                DateT = txtDateT.EditValue.ToString()
            };
            openForm.ShowDialog();
        }
    }
}