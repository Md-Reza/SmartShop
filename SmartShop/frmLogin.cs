using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using System;
using System.Windows.Forms;
using SmartShop.Desktop_Forms_Control;
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
                    if (userLogin.UserValidation(txtUserName.EditValue.ToString(), txtPassword.EditValue.ToString()))
                    {
                        Settings.Default.UserName = txtUserName.EditValue.ToString();
                        Settings.Default.LoginName = txtUserName.EditValue.ToString();
                        Settings.Default.Password = txtPassword.EditValue.ToString();
                       // SShopMainMenue mnuSells = new SShopMainMenue();
                       SalesMainForm mnuSells=new SalesMainForm();
                       this.Hide();
                        mnuSells.ShowDialog();
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

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            txtPassword.SelectAll();
            txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (ValidationProvider.Validate())
            {
                if (userLogin.UserValidation(txtUserName.EditValue.ToString(), txtPassword.EditValue.ToString()))
                {
                    Settings.Default.UserName = txtUserName.EditValue.ToString();
                    Settings.Default.LoginName = txtUserName.EditValue.ToString();
                    Settings.Default.Password = txtPassword.EditValue.ToString();
                    SalesMainForm mnuSells = new SalesMainForm();
                    this.Hide();
                    mnuSells.ShowDialog();
                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                }
                else
                {
                    XtraMessageBox.Show("User id password invalid");
                }

            }
        }
    }
}