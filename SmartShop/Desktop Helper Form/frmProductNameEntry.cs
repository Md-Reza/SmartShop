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
using SmartShop.Properties;
using SmartShop.Repository;
using static SmartShop.Interface.Interface;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmProductNameEntry : DevExpress.XtraEditors.XtraForm
    {
        public Command.DbCommand dbAccess;
        public string code;
        IBaseRepository<ProductName> baseRepository = new ProductNameRepository();
        IBaseRepository<CategoriesSetup> cateBaseRepository = new CategoriesRepository();
        ProductNameRepository productNameRepository = new ProductNameRepository();
        public frmProductNameEntry()
        {
            InitializeComponent();
        }
        private void LoadProduct()
        {
            cmbSupplyerName.Properties.DataSource = productNameRepository.GetAllSupplyerInformations().ToList();
            cmbSupplyerName.Properties.DisplayMember = "SupplyerName";
            cmbSupplyerName.Properties.ValueMember = "Id";

            cmbCategoryName.Properties.DataSource = cateBaseRepository.Get().ToList();
            cmbCategoryName.Properties.DisplayMember = "CategoryName";
            cmbCategoryName.Properties.ValueMember = "id";

            cmbBrand.Properties.DataSource = productNameRepository.GetAllBrand().ToList();
            cmbBrand.Properties.DisplayMember = "BrandName";
            cmbBrand.Properties.ValueMember = "BrandId";

            cmbColour.Properties.DataSource = productNameRepository.GetAllColour().ToList();
            cmbColour.Properties.DisplayMember = "ColourName";
            cmbColour.Properties.ValueMember = "ColourId";

            cmbSize.Properties.DataSource = productNameRepository.GetAllSize().ToList();
            cmbSize.Properties.DisplayMember = "SizeName";
            cmbSize.Properties.ValueMember = "SizeId";
        }

        public void LoadProductInformation(string code)
        {
            ProductName list = productNameRepository.GetByAll(code).FirstOrDefault();
            txtName.EditValue = list.Name;
            txtCode.EditValue = list.Code;
            cmbSupplyerName.EditValue = list.CompanyId;
            cmbCategoryName.EditValue = list.CategoryId;
            txtProductPrice.EditValue = list.ProductPrice;
            txtSellingPrice.EditValue = list.SellingPrice;
            txtVat.EditValue = list.VatPercent;
            txtReorderLevel.EditValue = list.ReorderLebel;
            pictureEdit1.EditValue = list.logo;
            txtDescription.EditValue = list.Description;
            cmbColour.EditValue = list.ColourId;
            cmbBrand.EditValue = list.BrandId;
            cmbSize.EditValue = list.SizeId;
            txtDiscountPercent.EditValue = list.DisCountPercent;
        }

        public void ProductNameUpdate(ProductName code)
        {
            baseRepository.Update(code);
        }

        private void frmProductNameEntry_Load(object sender, EventArgs e)
        {
            if (dbAccess == Command.DbCommand.Create)
            {
                txtCode.EditValue = @"--New--";
                LoadProduct();
                txtCode.Enabled = false;
            }
            else
            {
                LoadProduct();
                LoadProductInformation(code);
            }
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidationProvider.Validate()) return;

            if (dbAccess == Command.DbCommand.Create)
            {
                ProductName product = new ProductName()
                {
                    Name = txtName.EditValue.ToString(),
                    CategoryId = (int)cmbCategoryName.EditValue,
                    CompanyId = (int)cmbSupplyerName.EditValue,
                    ReorderLebel = Convert.ToInt16(txtReorderLevel.EditValue),
                    ProductPrice = Convert.ToDecimal(txtProductPrice.EditValue),
                    SellingPrice = Convert.ToDecimal(txtSellingPrice.EditValue),
                    VatPercent = Convert.ToDecimal(txtVat.EditValue),
                    logo = (byte[])pictureEdit1.EditValue,
                    Description = (string)txtDescription.EditValue,
                    Status = Connection.ValueCheck(chkActivation).ToString(),
                    BrandId = (int)cmbBrand.EditValue,
                    ColourId = (int)cmbColour.EditValue,
                    SizeId = (int)cmbSize.EditValue,
                    DisCountPercent = Convert.ToDecimal(txtDiscountPercent.EditValue),
                    CreateById = Settings.Default.UserName
                };
                baseRepository.Insert(product);
                XtraMessageBox.Show("Smart Shop Alert:- Product save successfully");
            }
            else if (dbAccess == Command.DbCommand.Update)
            {

            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductNameUpdate(new ProductName()
            {
                Name = txtName.EditValue.ToString(),
                CompanyId = Convert.ToInt16(cmbSupplyerName.EditValue),
                CategoryId = Convert.ToInt16(cmbCategoryName.EditValue),
                ProductPrice = Convert.ToDecimal(txtProductPrice.EditValue),
                SellingPrice = Convert.ToDecimal(txtSellingPrice.EditValue),
                VatPercent = Convert.ToDecimal(txtVat.EditValue),
                ReorderLebel = Convert.ToInt16(txtReorderLevel.EditValue),
                logo = (byte[])pictureEdit1.EditValue,
                Description = txtDescription.EditValue.ToString(),
                Code = txtCode.EditValue.ToString(),
                Status = Connection.ValueCheck(chkActivation),
                BrandId = (int)cmbBrand.EditValue,
                ColourId = (int)cmbColour.EditValue,
                SizeId = (int)cmbSize.EditValue,
                DisCountPercent = Convert.ToDecimal(txtDiscountPercent.EditValue),
                CreateById = Settings.Default.LoginName
            });
            XtraMessageBox.Show("Smart Shop Alert:- Product update successfully");
        }
    }
}