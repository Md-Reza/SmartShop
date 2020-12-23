using DevExpress.XtraEditors;
using SmartShop.Interface;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using static SmartShop.Interface.CustomerInfoInterface;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmCustomerEntry : DevExpress.XtraEditors.XtraForm
    {
        public Command.DbCommand dbAccess;
        public string custId;
        ICustRepository<CustomerInformation> _custRepository = new CustomersRepository();
        public frmCustomerEntry()
        {
            InitializeComponent();
            layoutControl1.AllowCustomization = false;
           // cmbGender.Properties.Items.AddRange(Enum.GetNames(typeof(Gender.GenderEnum)).ToList());

        }

        private void DbOperation()
        {
            if (!ValidationProvider.Validate()) return;

            try
            {
                CustomerInformation customer = new CustomerInformation();
                customer.CustId =0;
                customer.CustomerName = txtName.EditValue.ToString();
                customer.CustomerPresentAddress = (string) txtPresentAddress.EditValue;
                customer.CustomerPermanentAddress = (string) txtPermantAddress.EditValue;
                customer.ContactNo = (string) txtContactNo.EditValue;
                customer.Email = (string) txtEmail.EditValue;
                customer.Gender = cmbGender.EditValue.ToString();
                customer.Photo = (byte[]) pictureEdit1.EditValue;
                customer.CreateBy = Settings.Default.UserName;
                customer.CreateDateTime = DateTime.Now;
                customer.IsActive = (bool) chkActivation.EditValue;
                
                switch (dbAccess)
                {
                    case Command.DbCommand.Create:
                    {
                        _custRepository.ExecuteCustomers(customer);
                        XtraMessageBox.Show("Customer Information save successfully");
                        break;
                    }

                    case Command.DbCommand.Update:
                    {
                        _custRepository.ExecuteUpdateCustomers(customer);
                        XtraMessageBox.Show("Customer Information updated successfully");
                        break;
                    }

                }
            }

            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message);
            }
        }
        private void LoadCustomer(string custId)
        {
            IEnumerable<CustomerInformation>  information = _custRepository.GetByCustomer(custId);
            txtCustId.EditValue = information.FirstOrDefault().CustId;
            txtName.EditValue = information.FirstOrDefault().CustomerName;
            txtPermantAddress.EditValue = information.FirstOrDefault().CustomerPermanentAddress;
            txtPresentAddress.EditValue = information.FirstOrDefault().CustomerPresentAddress;
            txtContactNo.EditValue = information.FirstOrDefault().ContactNo;
            txtEmail.EditValue = information.FirstOrDefault().Email;
            cmbGender.EditValue = information.FirstOrDefault().Gender;
            pictureEdit1.EditValue = information.FirstOrDefault().Photo;
            chkActivation.EditValue = information.FirstOrDefault().IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbOperation();
        }

        private void frmCustomerEntry_Load(object sender, EventArgs e)
        {
            if (dbAccess == Command.DbCommand.Create)
            {
               txtCustId.EditValue = @"--New--";
            }
            else
                LoadCustomer(custId);
            cmbGender.Properties.Items.AddRange(Enum.GetNames(typeof(Gender.GenderEnum)).ToList());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}