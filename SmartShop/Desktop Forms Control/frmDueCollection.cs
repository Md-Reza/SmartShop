using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.DueCollection;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmDueCollection : DevExpress.XtraEditors.XtraForm
    {
        IDueRepository<ArrearCollection> _dueRepository = new DueCollectionRepository();
        public Command.DbCommand dbAccess;
        public string custId;
        public frmDueCollection()
        {
            InitializeComponent();
        }

        private void txtCustomerId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            IEnumerable<ArrearCollection> dueList = _dueRepository.GetCustomerArrear(txtCustomerId.EditValue.ToString());

            if (dueList.Any() && dueList.FirstOrDefault().LastDueAmount > 0)
            {
                txtCustomerName.EditValue = dueList.FirstOrDefault().CustomerName;
                txtTotalDues.EditValue = dueList.FirstOrDefault().LastDueAmount;
                txtPayAmount.SelectAll();
                txtPayAmount.Focus();
            }
            else
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show("No due found");
            }
            gridControl1.DataSource = _dueRepository.GetByDateArrearDueCollection(txtDate.EditValue.ToString());
        }

        private void frmDueCollection_Load(object sender, EventArgs e)
        {
            txtDate.EditValue = DateTime.Now.ToString("dd-MMM-yyyy");
            gridControl1.DataSource = _dueRepository.GetByDateArrearDueCollection(txtDate.EditValue.ToString());
            LoadArrearCollection(custId);
        }

        private void txtPayAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            txtLastDues.EditValue = Convert.ToInt16(txtTotalDues.EditValue) - Convert.ToInt16(txtPayAmount.EditValue);
            var dueAmount = Convert.ToInt16(txtLastDues.EditValue);
            if (dueAmount < 0)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show("Pay Amount is less then total amount");
                return;
            }
            btnSave.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var dueAmount = Convert.ToInt16(txtTotalDues.EditValue);
            if (dueAmount < 0)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show("Pay Amount is less then total amount");
                return;
            }

            if (txtTotalDues.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show("Pay Amount is less then total amount");
                return;
            }

            if (txtCustomerId.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show("Please input correct customer id.");
                return;
            }

            ArrearCollection arrearCollection = new ArrearCollection()
            {
                CustId = txtCustomerId.EditValue.ToString(),
                CustomerName = txtCustomerName.EditValue.ToString(),
                TransactionDate = Convert.ToDateTime(txtDate.EditValue),
                SalesMonth = Convert.ToDateTime(txtDate.EditValue).ToString("yyyyMM"),
                DueAmount = Convert.ToInt16(txtTotalDues.EditValue),
                PayAmount = Convert.ToInt16(txtPayAmount.EditValue),
                LastDueAmount = Convert.ToInt16(txtLastDues.EditValue),
                CreateBy = Settings.Default.UserName,
            };
            _dueRepository.ExecuteArrearCollection(arrearCollection);
            gridControl1.DataSource = _dueRepository.GetByDateArrearDueCollection(txtDate.EditValue.ToString());
            txtCustomerId.SelectAll();
            txtCustomerId.Focus();
            Clear();

        }

        public void LoadArrearCollection(string custId)
        {
            IEnumerable<ArrearCollection> dueList = _dueRepository.GetCustomerArrear(custId);
            if (dueList.Any())
            {
                txtCustomerName.EditValue = dueList.FirstOrDefault().CustomerName;
                txtCustomerId.EditValue = dueList.FirstOrDefault().CustId;
                txtTotalDues.EditValue = dueList.FirstOrDefault().LastDueAmount;
                txtLastDues.EditValue = dueList.FirstOrDefault().LastDueAmount;
                // txtPayAmount.EditValue = dueList.FirstOrDefault().PayAmount;
            }
            else
            {
                txtDate.EditValue = DateTime.Now.ToString("dd-MMM-yyyy");
                gridControl1.DataSource = _dueRepository.GetByDateArrearDueCollection(txtDate.EditValue.ToString());
            }

        }

        private void Clear()
        {
            txtCustomerName.EditValue = null;
            txtLastDues.EditValue = null;
            txtTotalDues.EditValue = null;
            txtPayAmount.EditValue = 0;
            gridControl1.DataSource = _dueRepository.GetByDateArrearDueCollection(txtDate.EditValue.ToString());

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}