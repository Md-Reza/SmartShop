using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmCalculator : DevExpress.XtraEditors.XtraForm
    {
        string operation = "";
        double value = 0;
        public int totalAmount = 0;
        private bool operation_passed = false;
        public List<SellesChild> getOrderList = new List<SellesChild>();
        public List<SellesChild> getAddOrderList = new List<SellesChild>();

        public long invoice;
        public long invoice2;
        SellsRepository _sellsRepository = new SellsRepository();
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
            //switch (operation)
            //{
            //    case "+":
            //        txtReturnAmount.EditValue = (value + double.Parse(txtReturnAmount.Text)).ToString();
            //        break;
            //    case "-":
            //        txtReturnAmount.EditValue = (value - double.Parse(txtReturnAmount.Text)).ToString();
            //        break;
            //    case "*":
            //        txtReturnAmount.EditValue = (value * double.Parse(txtReturnAmount.Text)).ToString();
            //        break;
            //    case "/":
            //        txtReturnAmount.EditValue = (value / double.Parse(txtReturnAmount.Text)).ToString();
            //        break;
            //    default:
            //        break;
            //}
            //operation_passed = false;
            //value = 0;


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
        }

        private void txtPayAmount_EditValueChanged(object sender, EventArgs e)
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
                       FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));
                return;
            }
            if (XtraMessageBox.Show($"Are you want to confirm this item {invoice2 }?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _sellsRepository.InsertSellsChildByItem(getOrderList);
                this.Close();
            }

        }
    }
}