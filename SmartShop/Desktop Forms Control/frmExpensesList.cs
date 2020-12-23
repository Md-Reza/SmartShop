using DevExpress.XtraEditors;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.Expenses;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmExpensesList : DevExpress.XtraEditors.XtraForm
    {
        private IExpenses<ExpensesList> enExpenses = new ExpensesRepository();
        public frmExpensesList()
        {
            InitializeComponent();
        }

        private void btnCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            LoadExpenseList();
        }

        private void LoadExpenseList()
        {
            gridControl1.DataSource = enExpenses.GetAllExpenses().ToList();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadExpenseList();
        }
    }
}