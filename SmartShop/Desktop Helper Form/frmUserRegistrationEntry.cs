using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using static SmartShop.Interface.IDepartment;
using static SmartShop.Interface.Interface;
using static SmartShop.Interface.IUserRegistration;
using System.Windows.Forms;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmUserRegistrationEntry : DevExpress.XtraEditors.XtraForm
    {
        public Command.DbCommand dbAccess;
        public string accountCode;
        public IBaseUserRegistration<EmployeeInformation> _userRegistration = new UserRepository();
        IBaseRepository<Desiganation> baseRepository = new DesiganationRepository();
        Idepartments<Departments> idepartments = new DepartmentRepository();

        public frmUserRegistrationEntry()
        {
            InitializeComponent();
            layoutControl1.AllowCustomization = false;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void DbOperation()
        {
            if (!ValidationProvider.Validate()) return;
            try
            {
                EmployeeInformation employeeInformation = new EmployeeInformation();
                employeeInformation.UserName = txtUserName.EditValue.ToString();
                employeeInformation.UserEmail =(string) txtEmail.EditValue;
                employeeInformation.FirstName = (string)txtFirstName.EditValue;
                employeeInformation.Password = (string)txtPassword.EditValue;
                employeeInformation.ConfirmPassword = (string)txtConfirmPassword.EditValue;
                employeeInformation.LastName = (string)txtLastName.EditValue;
                employeeInformation.FullName = (string)txtFullName.EditValue;
                employeeInformation.PresentAddress = (string)txtPresentAddress.EditValue;
                employeeInformation.PermanentAddress = (string)txtPermanentAddress.EditValue;
                employeeInformation.ReportingPerson = cmbRepotingPerson.EditValue.ToString();
                employeeInformation.MobileNo = (string)txtMobileNo.EditValue;
                employeeInformation.DeviceName = (string)txtDeviceName.EditValue;
                employeeInformation.DeviceQty = Convert.ToInt32(txtQty.EditValue);
                employeeInformation.IMEINo = (string)txtImeiNo.EditValue;
                employeeInformation.Photo = (byte[])txtPhoto.EditValue;
                employeeInformation.DepartmentCode = (string)cmbDepartment.EditValue;
                employeeInformation.DesiCode = (string)cmbDesiganation.EditValue;
                employeeInformation.BasicSalary = Convert.ToInt32(txtBasicSalary.EditValue);
                employeeInformation.HouseRent = Convert.ToInt32(txtHouseRent.EditValue);
                employeeInformation.MedicalAllonce = Convert.ToInt32(txtMedicalAllowance.EditValue);
                employeeInformation.DainingAllonce = Convert.ToInt32(txtDainingAllowance.EditValue);
                employeeInformation.CreateBy = Settings.Default.UserName;
                employeeInformation.UserStatus = (bool)chkActivation.EditValue;
                //{
                //    UserName = txtUserName.EditValue.ToString(),
                //    UserEmail = (string)txtEmail.EditValue,
                //    FirstName = (string)txtFirstName.EditValue,
                //    Password=(string)txtPassword.EditValue,
                //    ConfirmPassword= (string)txtConfirmPassword.EditValue,
                //    LastName = (string)txtLastName.EditValue,
                //    FullName = (string)txtFullName.EditValue,
                //    PresentAddress = (string)txtPresentAddress.EditValue,
                //    PermanentAddress = (string)txtPermanentAddress.EditValue,
                //    ReportingPerson = (string)cmbRepotingPerson.EditValue,
                //    MobileNo = (string)txtMobileNo.EditValue,
                //    DeviceName = (string)txtDeviceName.EditValue,
                //    DeviceQty = (int)txtQty.EditValue,
                //    IMEINo = (string)txtImeiNo.EditValue,
                //    Photo = (byte[])txtPhoto.EditValue,
                //    DepartmentCode = (string)cmbDepartment.EditValue,
                //    DesiCode = (string)cmbDesiganation.EditValue,
                //    BasicSalary = (int)txtBasicSalary.EditValue,
                //    HouseRent = (int)txtHouseRent.EditValue,
                //    MedicalAllonce = (int)txtMedicalAllowance.EditValue,
                //    DainingAllonce = (int)txtDainingAllowance.EditValue,
                //    CreateBy = Settings.Default.UserName,
                //    UserStatus = (bool)chkActivation.EditValue
                //};
                switch (dbAccess)
                {
                    case Command.DbCommand.Create:

                        _userRegistration.ExecuteUserRegistration(employeeInformation);
                        XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "User registration save successfully", "System Message", new[] { DialogResult.OK }, 
                            FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));
                        break;

                    case Command.DbCommand.Update:
                        _userRegistration.ExecuteUpdateUserRegistration(employeeInformation);
                        XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "User registration update successfully", "System Message", new[] { DialogResult.OK },
                           FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));
                        break;
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Employee information save error"+exception.Message.ToString());
            }
        }

        private void LoadSettings()
        {
            cmbDesiganation.Properties.DataSource = baseRepository.Get().ToList();
            cmbDesiganation.Properties.DisplayMember = "DesiName";
            cmbDesiganation.Properties.ValueMember = "DesiCode";

            cmbDepartment.Properties.DataSource = idepartments.GetAllDepartment().ToList();
            cmbDepartment.Properties.DisplayMember = "DepartmentName";
            cmbDepartment.Properties.ValueMember = "DepartmentCode";

            cmbRepotingPerson.Properties.DataSource = _userRegistration.GetAllUserRegistration().ToList();
            cmbRepotingPerson.Properties.DisplayMember = "FullName";
            cmbRepotingPerson.Properties.ValueMember = "AccountCode";
        }

        private void frmUserRegistrationEntry_Load(object sender, System.EventArgs e)
        {
            if (dbAccess == Command.DbCommand.Create)
            {
                txtAccountCode.EditValue = @"--New--";
                txtId.EditValue = @"--New--";
                LoadSettings();
            }
            else
            {
                LoadEmployee(accountCode);
                cmbDesiganation.EditValue = baseRepository.Get();
                LoadSettings();
            }
        }

        public void LoadEmployee(string accountCode)
        {
            IEnumerable<EmployeeInformation> employeeList = _userRegistration.GetByUserRegistration(accountCode);
            txtPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;
            txtUserName.Enabled = false;
            txtAccountCode.EditValue = employeeList.FirstOrDefault().AccountCode;
            txtUserName.EditValue = employeeList.FirstOrDefault().UserName;
            txtEmail.EditValue = employeeList.FirstOrDefault().UserEmail;
            txtFirstName.EditValue = employeeList.FirstOrDefault().FirstName;
            txtLastName.EditValue = employeeList.FirstOrDefault().LastName;
            txtFullName.EditValue = employeeList.FirstOrDefault().FullName;
            txtPassword.EditValue= employeeList.FirstOrDefault().Password;
            txtConfirmPassword.EditValue = employeeList.FirstOrDefault().ConfirmPassword;
            txtPresentAddress.EditValue = employeeList.FirstOrDefault().PresentAddress;
            txtPermanentAddress.EditValue = employeeList.FirstOrDefault().PermanentAddress;
            cmbRepotingPerson.EditValue = employeeList.FirstOrDefault().ReportingPerson;
            txtMobileNo.EditValue = employeeList.FirstOrDefault().MobileNo;
            txtDeviceName.EditValue = employeeList.FirstOrDefault().DeviceName;
            txtQty.EditValue = employeeList.FirstOrDefault().DeviceQty;
            txtImeiNo.EditValue = employeeList.FirstOrDefault().IMEINo;
            txtPhoto.EditValue = employeeList.FirstOrDefault().Photo;
            cmbDepartment.EditValue = employeeList.FirstOrDefault().DepartmentCode;
            cmbDesiganation.EditValue = employeeList.FirstOrDefault().DesiCode;
            txtBasicSalary.EditValue = employeeList.FirstOrDefault().BasicSalary;
            txtHouseRent.EditValue = employeeList.FirstOrDefault().HouseRent;
            txtMedicalAllowance.EditValue = employeeList.FirstOrDefault().MedicalAllonce;
            txtDainingAllowance.EditValue = employeeList.FirstOrDefault().DainingAllonce;
            chkActivation.EditValue = employeeList.FirstOrDefault().UserStatus;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbOperation();
        }

        private void txtFirstName_EditValueChanged(object sender, EventArgs e)
        {
            txtFullName.EditValue = txtFirstName.EditValue.ToString();
        }

        private void txtLastName_EditValueChanged(object sender, EventArgs e)
        {
            if (txtFirstName.EditValue == null)
            {
                txtFullName.EditValue = txtUserName.EditValue.ToString() + " " + txtLastName.EditValue.ToString();
            }
            else
            txtFullName.EditValue = txtFirstName.EditValue.ToString() +" "+ txtLastName.EditValue.ToString();
        }
    }
}