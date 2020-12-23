using SmartShop.Models;
using System;
using SmartShop.Properties;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using static SmartShop.Interface.Expenses;
using SmartShop.Repository;
using System.Collections.Generic;
using static SmartShop.Interface.IExpensesExecute;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmExpensesEntry : DevExpress.XtraEditors.XtraForm
    {
        public Command.DbCommand dbAccess;
        IExpenses<ExpensesList> expensesList = new ExpensesRepository();
        public List<ExpensesEntry> expensesEntries = new List<ExpensesEntry>();
        IExpensesEntry<ExpensesEntry> _expensesEntry = new ExpensesEntryRepository();
        public frmExpensesEntry()
        {
            InitializeComponent();
        }
        private void LoadExpensesList()
        {
            cmbExpenseList.Properties.DataSource = expensesList.GetAllExpenses();
            cmbExpenseList.Properties.DisplayMember = "ExpnsName";
            cmbExpenseList.Properties.ValueMember = "ExpnsId";
        }
        private void frmExpensesEntry_Load(object sender, System.EventArgs e)
        {
            txtDate.EditValue = DateTime.Now;
            txtUserName.EditValue = Settings.Default.UserName;
            LoadExpensesList();
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    frmExpensesListCreate openForm = new frmExpensesListCreate
                    {
                        dbAccess = Command.DbCommand.Create
                    };
                    openForm.FormClosed += OpenForm_FormClosed;
                    openForm.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Smart Shop Alert!:- Data Error" + exception);
            }
        }
        private void OpenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadExpensesList();
        }

        private void layoutControlGroup2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Add")
            {
                if (Convert.ToInt32(txtAmount.EditValue) <= 0)
                {
                    XtraMessageBox.Show("Please input correct amount.");
                    return;
                }
                expensesEntries.Add(new ExpensesEntry()
                {
                    EntryDate = Convert.ToDateTime(txtDate.EditValue).Date,
                    SalesMonth = Convert.ToDateTime(txtDate.EditValue).ToString("yyyyMM"),
                    ExpnsId = Convert.ToInt16(cmbExpenseList.EditValue),
                    ExpenseAmount = Convert.ToInt32(txtAmount.EditValue),
                    Remarks = (string)txtRemarks.EditValue,
                    CreateBy = Settings.Default.UserName,
                });

                gridControl1.RefreshDataSource();
                gridControl1.DataSource = expensesEntries;
                txtAmount.EditValue = 0;

            }
            if (e.Button.Properties.Caption == "Delete")
            {
                gridView1.DeleteSelectedRows();
                gridView1.RefreshData();
            }
            if (e.Button.Properties.Caption == "Cancel")
            {
                this.Close();
            }
        }
        private void DbOperation()
        {
            if (gridView1.SelectedRowsCount>0)
            {
                List<ExpensesEntry> expenses = new List<ExpensesEntry>();
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    expenses.Add(new ExpensesEntry()
                    {
                        EntryDate = Convert.ToDateTime(gridView1.GetRowCellValue(i, EntryDate)),
                        SalesMonth = gridView1.GetRowCellValue(i, SalesMonth).ToString(),
                        ExpnsId = Convert.ToInt16(gridView1.GetRowCellValue(i, ExpnsId)),
                        ExpenseAmount = Convert.ToInt32(gridView1.GetRowCellValue(i, ExpenseAmount)),
                        Remarks = gridView1.GetRowCellValue(i, Remarks) == null ? null : gridView1.GetRowCellValue(i, Remarks).ToString(),
                        CreateBy = gridView1.GetRowCellValue(i, CreateBy).ToString(),
                    });
                }
                _expensesEntry.InsertExpensesEntry(expenses);
                XtraMessageBox.Show("Expenses save successfully");
                gridControl1.DataSource = null;
            }
            
            else
                XtraMessageBox.Show("Please add at least one expenses.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbOperation();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbExpenseList_EditValueChanged(object sender, EventArgs e)
        {
            txtAmount.SelectAll();
            txtAmount.Focus();
        }
    }
}