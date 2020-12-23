using SmartShop.Models;
using SmartShop.Repository;
using System;
using DevExpress.XtraEditors;
using static SmartShop.Interface.Expenses;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmExpensesListCreate : DevExpress.XtraEditors.XtraForm
    {
        public Command.DbCommand dbAccess;
        private IExpenses<ExpensesList> enExpenses = new ExpensesRepository();

        public frmExpensesListCreate()
        {
            InitializeComponent();
        }

        private void DbOperation()
        {
            ExpensesList expensesList=new ExpensesList()
            {
                ExpnsId =Convert.ToInt16( txtId.EditValue),
                ExpnsName =(string)txtName.EditValue,
                Remarks = (string)txtRemarks.EditValue,
                IsActive = (bool)chkIsActive.EditValue
            };
            if (dbAccess == Command.DbCommand.Create)
            {
                enExpenses.ExecuteExpensesList(expensesList);
                XtraMessageBox.Show("Expense Reasons Create Successfully");
            }
        }

        private void frmExpensesListCreate_Load(object sender, EventArgs e)
        {
            if (dbAccess == Command.DbCommand.Create)
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbOperation();
        }
    }
}