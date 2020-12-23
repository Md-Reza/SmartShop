using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SmartShop.Properties;
using static SmartShop.Interface.BankInterface;
using SmartShop.Repository;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using static SmartShop.Interface.BankTransactionInterface;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmBankTransactionEntry : DevExpress.XtraEditors.XtraForm
    {
        public Command.DbCommand dbAccess;
        public List<BankTransaction> bankTransaction=new List<BankTransaction>();
        IBank<Bank> iBank = new BankRepository();
        IBankTransaction<BankTransaction> bankTrnsRepository = new BankTransactionRepository();
        BankTransactionRepository bankTransactionRepository = new BankTransactionRepository();
        public frmBankTransactionEntry()
        {
            InitializeComponent();
            layoutControl1.AllowCustomization = false;
        }

        private void cmbTransType_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbTransType.EditValue.ToString() == @"Debit")
            {
                txtCreditAmt.Enabled = false;
                txtDebitAmt.Enabled = true;
                txtDebitAmt.Focus();
                txtDebitAmt.SelectAll();
            }
            else  if (cmbTransType.EditValue.ToString() == @"Credit")
            {
                txtDebitAmt.Enabled = false;
                txtCreditAmt.Enabled = true;
                txtCreditAmt.Focus();
                txtCreditAmt.SelectAll();
            }
        }

        private void frmBankTransactionEntry_Load(object sender, EventArgs e)
        {
            cmbTransType.Properties.Items.AddRange(Enum.GetNames(typeof(Command.Transaction)).ToList());
            txtTransDate.EditValue = DateTime.Now;
        }

        private void layoutControlGroup2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if(e.Button.Properties.Caption=="Add Item")
            {
                if (txtAccountNo.EditValue == null)
                {
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Please Input Correct Bank Account", "System Message", new[] { DialogResult.OK },
                        FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                    return;
                }
                if (cmbTransType.EditValue.ToString() == @"Debit" && Convert.ToInt32(txtDebitAmt.EditValue)<=0)
                {
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Please Input Correct Debit Amount", "System Message", new[] { DialogResult.OK },
                        FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                    return;
                }
                if (cmbTransType.EditValue.ToString() == @"Credit" && Convert.ToInt32(txtCreditAmt.EditValue) <= 0)
                {
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Please Input Correct Credit Amount", "System Message", new[] { DialogResult.OK },
                        FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                    return;
                }

                bankTransaction.Add(new BankTransaction()
                {
                    AccountNo = txtAccountNo.EditValue.ToString(),
                    TransDate = Convert.ToDateTime(txtTransDate.EditValue),
                    SalesMonth = Convert.ToDateTime(txtTransDate.EditValue).ToString("yyyyMM"),
                    OpeningAmount = Convert.ToInt32(txtOpeningAmount.EditValue),
                    TransType = cmbTransType.EditValue.ToString(),
                    DebitAmount = Convert.ToInt32(txtDebitAmt.EditValue),
                    CreditAmount = Convert.ToInt32(txtCreditAmt.EditValue),
                    MiscAmount = Convert.ToInt32(txtMiscAmt.EditValue),
                    CreateBy =Settings.Default.LoginName
                });
                gridControl1.RefreshDataSource();
                gridControl1.DataSource = bankTransaction;
                txtDebitAmt.EditValue = 0;
                txtCreditAmt.EditValue = 0;
                txtMiscAmt.EditValue = 0;
            }
            if (e.Button.Properties.Caption == "Delete")
            {
                gridView1.DeleteSelectedRows();
                gridView1.RefreshData();
            }
        }
        private void DbOperation()
        {
            if (gridView1.RowCount >= 1)
            {
                List<BankTransaction> bankTrans = new List<BankTransaction>();
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    bankTrans.Add(new BankTransaction()
                    {
                        AccountNo = gridView1.GetRowCellValue(i, AccountNo).ToString(),
                        TransDate =Convert.ToDateTime( gridView1.GetRowCellValue(i,TransDate)),
                        SalesMonth = Convert.ToDateTime(txtTransDate.EditValue).ToString("yyyyMM"),
                        OpeningAmount = Convert.ToInt32(txtOpeningAmount.EditValue),
                        TransType = gridView1.GetRowCellValue(i, TransType).ToString(),
                        DebitAmount = Convert.ToInt32(gridView1.GetRowCellValue(i,DebitAmount)),
                        CreditAmount = Convert.ToInt32(gridView1.GetRowCellValue(i, CreditAmount)),
                        MiscAmount = Convert.ToInt32(gridView1.GetRowCellValue(i, MiscAmount)),
                        CreateBy = Settings.Default.LoginName
                    });
                }
                bankTransactionRepository.InsertBankTransaction(bankTransaction);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Transcation save successfully", "System Message", new[] { DialogResult.OK },
                  FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));
                gridControl1.DataSource = null;
            }
            else
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No Data Found", "System Message", new[] { DialogResult.OK },
                  FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
            }
            
        }
        private void txtAccountNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var allBank = iBank.GetByBankId(txtAccountNo.EditValue);
            if (allBank.Any())
            {
                txtBranceName.EditValue = allBank.FirstOrDefault().BankName;
                cmbTransType.Focus();
            }
            else
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "No Bank Account Found", "System Message", new[] { DialogResult.OK },
                FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
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