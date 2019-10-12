using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SmartShop.Interface;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using static SmartShop.Interface.Interface;

namespace SmartShop
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        IBaseRepository<UserLogin> baseRepository = new UserLoginRepository();
        UserLoginRepository userLogin = new UserLoginRepository();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidationProvider.Validate())
                {
                    if (userLogin.UserValidation(txtUserName.EditValue.ToString(),txtPassword.EditValue.ToString()))
                    {
                        Settings.Default.UserName = txtUserName.EditValue.ToString();
                        Settings.Default.LoginName=txtUserName.EditValue.ToString();
                        Settings.Default.Password = txtPassword.EditValue.ToString();
                        SShopMainMenue mnuSells = new SShopMainMenue();
                        mnuSells.ShowDialog();
                        this.Hide();
                        progressBarControl1.PerformStep();
                        progressBarControl1.Update();
                    }
                    else
                    {
                        XtraMessageBox.Show("User id password invalid");
                    }

                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message);
            }
        }
    }
}