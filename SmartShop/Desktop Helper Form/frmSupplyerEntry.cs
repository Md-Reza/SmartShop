using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Linq;
using static SmartShop.Interface.Interface;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmSupplyerEntry : DevExpress.XtraEditors.XtraForm
    {
        IBaseRepository<SupplyerInformation> baseRepository = new SupplyerInformationRepository();
        SupplyerInformationRepository supplyerInformation = new SupplyerInformationRepository();

        public Command.DbCommand dbAccess;
        public string supplyerName;
        public frmSupplyerEntry()
        {
           // layoutControl1.AllowCustomization = false;
            InitializeComponent();
            layoutControl1.AllowCustomization = false;
        }
        public void LoadSupplyer(string name)
        {
            SupplyerInformation list = supplyerInformation.GetSupplyerInformation(name).FirstOrDefault();
            txtName.EditValue = list.SupplyerName;
            txtAddress.EditValue = list.Address;
            txtContactPerson.EditValue = list.ContactPerson;
            txtMobile2.EditValue = list.ContactPersonMobileNo;
            txtEmail.EditValue = list.Email;
            pictureEdit1.EditValue = list.Logo;
            txtMobile1.EditValue = list.Mobile;
        }
        public void SupplyerUpate(SupplyerInformation name)
        {
            baseRepository.Update(name);
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (ValidationProvider.Validate())
            {
                SupplyerInformation dbValue = new SupplyerInformation();
                dbValue.SupplyerName = (string)txtName.EditValue;
                dbValue.Address = (string)txtAddress.EditValue;
                dbValue.ContactPerson = (string)txtContactPerson.EditValue;
                dbValue.ContactPersonMobileNo = (string)txtContactPerson.EditValue;
                dbValue.Mobile = (string)txtMobile1.EditValue.ToString();
                dbValue.Email = (string)txtEmail.EditValue.ToString();
                dbValue.Status = (bool)Activeted.EditValue;
                dbValue.Logo = (byte[])pictureEdit1.EditValue;
                if (dbAccess == Command.DbCommand.Create)
                {
                    baseRepository.Insert(dbValue);
                    XtraMessageBox.Show(@"Smart Shop Alert! supplier save successfully");
                }
                else
                {
                    
                }
            }
        }

        private void frmSupplyerEntry_Load(object sender, EventArgs e)
        {
            if (dbAccess == Command.DbCommand.Create)
            {

            }
            else
                LoadSupplyer(supplyerName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
