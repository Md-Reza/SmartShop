using DevExpress.XtraEditors;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.BankInterface;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmBank : DevExpress.XtraEditors.XtraForm
    {
        IBank<Bank> bankRepo = new BankRepository();
        public frmBank()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                {
                    frmBankEntry openForm = new frmBankEntry
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
            gridControl1.DataSource = bankRepo.GetAllBank();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                {
                    frmBankEntry openForm = new frmBankEntry
                    {
                        dbAccess = Command.DbCommand.Update,
                        AccountNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, AccountNo).ToString(),
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

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = bankRepo.GetAllBank();
        }
    }
}