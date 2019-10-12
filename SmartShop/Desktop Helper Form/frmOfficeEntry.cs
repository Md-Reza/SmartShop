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
using SmartShop.Models;
using SmartShop.Repository;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmOfficeEntry : DevExpress.XtraEditors.XtraForm
    {
        public Command.DbCommand dbAccess;
        ComapnySetupRepository comapnySetupRepository = new ComapnySetupRepository();
        public frmOfficeEntry()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidationProvider.Validate())
                {
                    CompanyInformation company = new CompanyInformation()
                    {
                        Name = txtName.EditValue.ToString(),
                        Address = txtAddress.EditValue.ToString(),
                        FactoryAddress = txtFactoryAddress.EditValue.ToString(),
                        ContactNo = txtContactNo.EditValue.ToString(),
                        Email = txtEmail.EditValue.ToString(),
                        Fax = txtFax.EditValue.ToString(),
                        Logo = (byte[])pictureEdit1.EditValue,
                        CEO = txtCeo.EditValue.ToString(),
                        AppInstallDate = txtAppInsDate.DateTime,
                    };
                    comapnySetupRepository.CompanyInsert(company);
                    XtraMessageBox.Show("Company save successfully");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getOfficeData()
        {
            IEnumerable<CompanyInformation> oData = comapnySetupRepository.GetCompanyData();
            txtName.EditValue = oData.FirstOrDefault().Name;
            txtAddress.EditValue = oData.FirstOrDefault().Address;
            txtFactoryAddress.EditValue = oData.FirstOrDefault().FactoryAddress;
            txtContactNo.EditValue = oData.FirstOrDefault().ContactNo;
            txtFax.EditValue = oData.FirstOrDefault().Fax;
            txtEmail.EditValue = oData.FirstOrDefault().Email;
            txtCeo.EditValue = oData.FirstOrDefault().CEO;
            txtAppInsDate.EditValue = oData.FirstOrDefault().AppInstallDate;
            pictureEdit1.EditValue = oData.FirstOrDefault().Logo;
        }
        private void frmOfficeEntry_Load(object sender, EventArgs e)
        {
            getOfficeData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}