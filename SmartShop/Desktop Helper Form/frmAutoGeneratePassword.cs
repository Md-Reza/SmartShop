using System;
using System.Linq;
using System.Text;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmAutoGeneratePassword : DevExpress.XtraEditors.XtraForm
    {
        public frmAutoGeneratePassword()
        {
            InitializeComponent();
        }
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            textEdit1.EditValue = res;
            return res.ToString();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CreatePassword(Convert.ToInt32(textEdit2.EditValue));
        }
    }
}