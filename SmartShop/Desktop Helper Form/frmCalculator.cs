using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmCalculator : DevExpress.XtraEditors.XtraForm
    {
        string operation = "";
        double value = 0;
       private bool operation_passed = false;
        public frmCalculator()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((txtResult.Text == "0")||(operation_passed))
                txtResult.Text=null;
                SimpleButton button = (SimpleButton)sender;
            txtResult.EditValue = txtResult.EditValue + button.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
             operation = button.Text;
            //txtResult.EditValue = txtResult.EditValue + button.Text;
            value = double.Parse(txtResult.Text);
            operation_passed = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    txtResult.EditValue = (value + double.Parse(txtResult.Text)).ToString();
                    break;
                case "-":
                    txtResult.EditValue = (value - double.Parse(txtResult.Text)).ToString();
                    break;
                case "*":
                    txtResult.EditValue = (value * double.Parse(txtResult.Text)).ToString();
                    break;
                case "/":
                    txtResult.EditValue = (value / double.Parse(txtResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            operation_passed = false;
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            txtResult.EditValue = "";
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            txtResult.EditValue = "";
        }
    }
}