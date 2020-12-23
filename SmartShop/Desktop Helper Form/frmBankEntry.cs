using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using System;
using System.Linq;
using static SmartShop.Interface.BankInterface;
using System.Windows.Forms;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmBankEntry : DevExpress.XtraEditors.XtraForm
    {
        public Command.DbCommand dbAccess;
        public string AccountNo;
        IBank<Bank> bankRepo = new BankRepository();
        public frmBankEntry() 
        { InitializeComponent(); }

        private void frmBankEntry_Load(object sender, EventArgs e)
        {
            if (dbAccess == Command.DbCommand.Create)
            {
                txtBankId.EditValue = 0;
            }
            else
            {
                LoadBank(AccountNo);
            }
        }

        private void LoadBank(string bankId)
        {
            var dbValue = bankRepo.GetByBankId(bankId);
            txtBankId.EditValue = dbValue.FirstOrDefault().BankId;
            txtBankName.EditValue = dbValue.FirstOrDefault().BankName;
            txtAccountNumber.EditValue = dbValue.FirstOrDefault().AccountNo;
            txtAddress.EditValue = dbValue.FirstOrDefault().BankAddress;
            chkActivation.EditValue = dbValue.FirstOrDefault().Status;
        }

        private void DbOperation()
        {
            if (!ValidationProvider.Validate()) return;
            try
            {
                Bank bank = new Bank()
                {
                    BankId = (int)txtBankId.EditValue,
                    BankName = txtBankName.EditValue.ToString(),
                    AccountNo = txtAccountNumber.EditValue.ToString(),
                    BankAddress = (string)txtAddress.EditValue,
                    Status = (bool)chkActivation.EditValue,
                    CreateBy = Settings.Default.LoginName
                };
                if (dbAccess == Command.DbCommand.Create)
                {
                    bankRepo.ExecuteBankEntry(bank);
                    XtraMessageBox.Show("Bank save successfully");
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Bank save successfully", "System Message", new[] { DialogResult.OK },
                   FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));
                }
                else if (dbAccess == Command.DbCommand.Update)
                {
                    bankRepo.UpdateEntry(bank);
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Bank update successfully", "System Message", new[] { DialogResult.OK },
                     FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.ToString());
            }

        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbOperation();
        }
    }
}