using DevExpress.XtraEditors;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.IUserRegistration;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmUserRegistration : DevExpress.XtraEditors.XtraForm
    {
        IBaseUserRegistration<EmployeeInformation> _userRegistration = new UserRepository();
        public frmUserRegistration()
        {
            InitializeComponent();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmUserRegistrationEntry openForm = new frmUserRegistrationEntry()
                {
                    dbAccess = Command.DbCommand.Create
                };
                openForm.FormClosed += OpenForm_FormClosed;
                openForm.ShowDialog();
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Smart Shop Alert!:- Data Error" + exception.Message);
            }
        }

        private void OpenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridControl1.DataSource = _userRegistration.GetAllUserRegistration().ToList();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = _userRegistration.GetAllUserRegistration().ToList();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmUserRegistrationEntry openForm = new frmUserRegistrationEntry()
                {
                    dbAccess = Command.DbCommand.Update,
                    accountCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,AccountCode).ToString()
                };
                openForm.FormClosed += OpenForm_FormClosed;
                openForm.ShowDialog();
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "mart Shop Alert!:-Data Error" + exception.Message, "System Message", new[] { DialogResult.OK },
                          FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
            }
        }
    }
}