using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Repository;
using static SmartShop.Interface.Interface;
using SmartShop.Properties;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmCategoriesSetupEntry : DevExpress.XtraEditors.XtraForm
    {
        IBaseRepository<CategoriesSetup> baseRepository = new CategoriesRepository();
        CategoriesRepository categoriesRepository = new CategoriesRepository();
        public Command.DbCommand dbAccess;
        public string categoriesName;
        public frmCategoriesSetupEntry()
        {
            InitializeComponent();
            layoutControl1.AllowCustomization = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CategoriesLoad(string Name)
        {
            CategoriesSetup list = categoriesRepository.GetCategoriesName(Name).FirstOrDefault();
            txtCategoryName.EditValue = list.CategoryName;
            pictureEdit1.EditValue = list.Logo;
            chkActiveation.EditValue = list.Status;
            txtCode.EditValue = list.id;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidationProvider.Validate())
                {
                    CategoriesSetup categoriesSetup = new CategoriesSetup()
                    {
                        CategoryName = (string)txtCategoryName.EditValue,
                        Logo = (byte[])pictureEdit1.EditValue,
                        Status = chkActiveation.EditValue.ToString(),
                        CreateBy =Settings.Default.UserName
                    };

                    if (dbAccess == Command.DbCommand.Create)
                    {
                        baseRepository.Insert(categoriesSetup);
                        XtraMessageBox.Show("Smart Shop Alert!- Categories Save Successfully");
                    }
                    else if (dbAccess == Command.DbCommand.Update)
                    {
                    }
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Smart Shop Alert!- Categories Save Error",exception.Message);
            }
        }
        private void UpdateCategory(CategoriesSetup name)
        {
            baseRepository.Update(name);
        }

        private void frmCategoriesSetupEntry_Load(object sender, EventArgs e)
        {
            if (dbAccess == Command.DbCommand.Create)
            {
                txtCode.EditValue = @"--New--";
            }
            else
            {
               CategoriesLoad(categoriesName);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateCategory(new CategoriesSetup()
            {
                CategoryName = txtCategoryName.EditValue.ToString(),
                Logo = (byte[])pictureEdit1.EditValue,
                CreateDate = DateTime.Now,
                CreateBy = "Create"
            });
            XtraMessageBox.Show("Smart Shop Alert!- Categories Updated");
        }
    }
}