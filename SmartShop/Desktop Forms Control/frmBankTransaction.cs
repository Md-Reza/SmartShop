using DevExpress.XtraEditors;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.BankTransactionInterface;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmBankTransaction : DevExpress.XtraEditors.XtraForm
    {
        IBankTransaction<BankTransaction> bankTrnsRepo = new BankTransactionRepository();
        public frmBankTransaction()
        {
            InitializeComponent();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                {
                    frmBankTransactionEntry openForm = new frmBankTransactionEntry
                    {
                        dbAccess = Command.DbCommand.Create,
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
            gridControl1.DataSource = null;
            gridControl1.DataSource = bankTrnsRepo.GetAllBankTransctionDate(txtDateF.EditValue.ToString(),txtDateT.EditValue.ToString());
        }

        private void frmBankTransaction_Load(object sender, EventArgs e)
        {
            txtDateF.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            txtDateT.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void btnView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource=  bankTrnsRepo.GetAllBankTransctionDate(txtDateF.EditValue.ToString(), txtDateT.EditValue.ToString());
        }
    }
}