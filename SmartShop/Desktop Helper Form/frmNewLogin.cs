using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Repository;
using SmartShop.Properties;
using System;
using static SmartShop.Interface.Interface;
using SmartShop.Desktop_Forms_Control;
using System.Windows.Forms;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmNewLogin : DevExpress.XtraEditors.XtraForm
    {
        IBaseRepository<UserLogin> baseRepository = new UserLoginRepository();
        UserLoginRepository userLogin = new UserLoginRepository();
        string activationCode = "Pr0tecti0nbyReza";
        public frmNewLogin()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidationProvider.Validate())
                {
                    if (activationCode != Settings.Default.ActiationCode)
                    {
                        XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Activation Code not match please contact system administrator", "System Message", new[] { DialogResult.OK },
                                          FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                        return;
                    }

                    if (userLogin.UserValidation(txtUser.EditValue.ToString(), txtPassword.EditValue.ToString()))
                    {
                        Settings.Default.UserName = txtUser.EditValue.ToString();
                        Settings.Default.LoginName = txtUser.EditValue.ToString();
                        Settings.Default.Password = txtPassword.EditValue.ToString();
                        // SShopMainMenue mnuSells = new SShopMainMenue();
                        SalesMainForm mnuSells = new SalesMainForm();
                        this.Hide();
                        mnuSells.ShowDialog();
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

        private void txtUser_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
                if (userLogin.UserValidation(txtUser.EditValue.ToString(), txtPassword.EditValue.ToString()))
                {
                    Settings.Default.UserName = txtUser.EditValue.ToString();
                    Settings.Default.LoginName = txtUser.EditValue.ToString();
                    Settings.Default.Password = txtPassword.EditValue.ToString();
                    SalesMainForm mnuSells = new SalesMainForm();
                    this.Hide();
                    mnuSells.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("User id password invalid");
                    txtPassword.SelectAll();
                }
            }
        }
        private void frmNewLogin_Load(object sender, EventArgs e)
        {
            Settings.Default.DataBaseName = System.Environment.MachineName;
            if (Settings.Default.UserName == string.Empty) return;
            txtPassword.Focus();
            txtUser.EditValue = Settings.Default.UserName;
            txtPassword.EditValue = Settings.Default.Password;
        }

        private void chkRememberPassword_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.UserName = txtUser.EditValue.ToString();
            Settings.Default.LoginName = txtUser.EditValue.ToString();
            Settings.Default.Password = txtPassword.EditValue.ToString();
            Settings.Default.Save();
        }

        private void hlUserRegistration_Click(object sender, EventArgs e)
        {
            UserLogin userLogin = new UserLogin();
            if (Settings.Default.ActiationCode == activationCode)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "You are Activated", "System Message", new[] { DialogResult.OK },
                                          FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationBlue()));
                return;
            }

            UcActivation ucActivation = new UcActivation(userLogin);
            DialogResult result = XtraDialog.Show(ucActivation, "Smart Shop Filter", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                if (userLogin.ActiationCode != activationCode)
                {
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Activation Code not match please contact system administrator", "System Message", new[] { DialogResult.OK },
                                           FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                    Settings.Default.ActiationCode = userLogin.ActiationCode.ToString();
                    Settings.Default.Save();
                    return;
                }
                else
                {
                    XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "You are Activated", "System Message", new[] { DialogResult.OK },
                                              FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
                    Settings.Default.ActiationCode = userLogin.ActiationCode.ToString();
                    Settings.Default.Save();
                }
            }
        }
    }
}