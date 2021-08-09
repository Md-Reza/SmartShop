using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.CustomerInfoInterface;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmCalculator : DevExpress.XtraEditors.XtraForm
    {
        string operation = "";
        double value = 0;
        public int totalAmount = 0;
        public DateTime salesDate ;
        private bool operation_passed = false;
        public List<SellesChild> getOrderList = new List<SellesChild>();
        public List<SellesChild> getAddOrderList = new List<SellesChild>();

        public long invoice;
        public long invoice2;
        SellsRepository _sellsRepository = new SellsRepository();
        ICustRepository<CustomerInformation> _custRepository = new CustomersRepository();
        public frmCalculator()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((txtPayAmount.Text == "0") || (operation_passed))
                txtReturnAmount.Text = null;
            SimpleButton button = (SimpleButton)sender;
            txtPayAmount.EditValue = txtPayAmount.EditValue + button.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
            operation = button.Text;
            //txtResult.EditValue = txtResult.EditValue + button.Text;
            value = double.Parse(txtPayAmount.Text);
            operation_passed = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtReturnAmount.EditValue) < 0)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Return Amount is incorrect", "System Message", new[] { DialogResult.OK },
                       FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));
                return;
            }

            txtReturnAmount.EditValue = Convert.ToInt32(txtTotalAmount.EditValue) - (Convert.ToInt32(txtPayAmount.EditValue) + Convert.ToInt32(txtSpecialAmount.EditValue));
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            txtPayAmount.EditValue = "";
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            txtPayAmount.EditValue = "";
        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {
            txtTotalAmount.EditValue = totalAmount;
            txtReturnAmount.EditValue = totalAmount;
            getAddOrderList = getOrderList.ToList();
            invoice2 = invoice;
            LoadCustomer();
        }

        private void txtPayAmount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIsDue.Checked)
                {
                    int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                    int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue) - Convert.ToInt32(txtSpecialAmount.EditValue);
                    txtDueAmount.EditValue = totalAmount - payAmount;
                    txtReturnAmount.EditValue = 0;
                }
                else
                {
                    int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                    int specialDiscount = Convert.ToInt32(txtSpecialAmount.EditValue);
                    int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue) - Convert.ToInt32(txtSpecialAmount.EditValue);
                    txtReturnAmount.EditValue = payAmount - totalAmount;
                    txtDueAmount.EditValue = 0;
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Incorrect amount", "System Message", new[] { DialogResult.OK },
                        FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));
                return;
            }
        }

        private void txtSpecialAmount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPayAmount.EditValue == null)
                {
                    txtPayAmount.EditValue = 0;
                    return;
                }
                if (txtPayAmount.EditValue.ToString() == "")
                {
                    txtPayAmount.EditValue = 0;
                    return;
                }
                txtReturnAmount.EditValue = (Convert.ToInt32(txtPayAmount.EditValue) + Convert.ToInt32(txtSpecialAmount.EditValue)) - Convert.ToInt32(txtTotalAmount.EditValue);
            }
            catch (Exception)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Incorrect amount", "System Message", new[] { DialogResult.OK },
                        FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtReturnAmount.EditValue) < 0)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Return Amount is incorrect", "System Message", new[] { DialogResult.OK },
                       FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }
            if (chkIsDue.Checked && cmbCustomerName.EditValue == null)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Definitely added customer name", "System Message", new[] { DialogResult.OK },
                       FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                return;
            }

            if (XtraMessageBox.Show($"Are you want to confirm this item {invoice2 }?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SellsParent sellsParent = new SellsParent()
                {
                    SellsInvoice = invoice.ToString(),
                    SellsDate = salesDate,
                    SalesMonth = Convert.ToDateTime(salesDate).ToString("yyyyMM"),
                    CustomerName = Convert.ToInt32(cmbCustomerName.EditValue),
                    ContactNo = (string)txtContactNo.EditValue,
                    TotalAmount = Convert.ToInt32(txtTotalAmount.EditValue),
                    PayAmount = Convert.ToInt32(txtPayAmount.EditValue),
                    ReturnAmount = Convert.ToInt32(txtReturnAmount.EditValue),
                    DueAmount = Convert.ToInt32(txtDueAmount.EditValue),
                    SellsBy = Settings.Default.UserName,
                    PcName = Environment.MachineName
                };
                _sellsRepository.InsertSellsParent(sellsParent);
                _sellsRepository.InsertSellsChild(getOrderList);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Order has been successfully saved", "System Message", new[] { DialogResult.OK },
                     FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));

                this.Close();
            }

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    frmCustomerEntry openForm = new frmCustomerEntry
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
       private void LoadCustomer()
        {
            cmbCustomerName.Properties.DataSource = _custRepository.GetAllCustomer();
            cmbCustomerName.Properties.DisplayMember = "CustomerName";
            cmbCustomerName.Properties.ValueMember = "CustId";
        }
        private void OpenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadCustomer();
        }

        private void cmbCustomerName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtContactNo.EditValue = _custRepository.GetAllCustomer().Where(f => Convert.ToString(f.CustId) == cmbCustomerName.EditValue.ToString()).FirstOrDefault().ContactNo;
                txtCustomerDue.EditValue = _custRepository.GetAllCustomerArrear(cmbCustomerName.EditValue.ToString()).FirstOrDefault().DueAmount;
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message);
            }
        }

        private void chkIsDue_EditValueChanged(object sender, EventArgs e)
        {
            if (chkIsDue.Checked)
            {
                int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue) - Convert.ToInt32(txtSpecialAmount.EditValue);
                txtDueAmount.EditValue = totalAmount - payAmount;
                txtReturnAmount.EditValue = 0;
            }
            else
            {
                int payAmount = Convert.ToInt32(txtPayAmount.EditValue);
                int specialDiscount = Convert.ToInt32(txtSpecialAmount.EditValue);
                int totalAmount = Convert.ToInt32(txtTotalAmount.EditValue) - Convert.ToInt32(txtSpecialAmount.EditValue);
                txtReturnAmount.EditValue = payAmount - totalAmount;
                txtDueAmount.EditValue = 0;
            }
        }
    }
}