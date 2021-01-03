using DevExpress.XtraEditors;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using System;
using System.Linq;
using System.Windows.Forms;
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
            layoutControl1.AllowCustomization = false;
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
            cmbColour.Properties.ValueMember = "ColurId";

            cmbSize.Properties.DataSource = productNameRepository.GetAllSize().ToList();
            cmbSize.Properties.DisplayMember = "SizeName";
            cmbSize.Properties.ValueMember = "SizeId";
        }

        public void LoadProductInformation(string code)
        {
            ProductName list = productNameRepository.GetByAll(code).FirstOrDefault();
            txtName.EditValue = list.Name;
            txtCode.EditValue = list.ProductCode;
            cmbSupplyerName.EditValue = list.CompanyId;
            cmbCategoryName.EditValue = list.CategoryId;
            txtProductPrice.EditValue = list.PurchasePrice;
            txtSellingPrice.EditValue = list.SellingPrice;
            txtVat.EditValue = list.VatPercent;
            txtReorderLevel.EditValue = list.ReorderLebel;
            pictureEdit1.EditValue = list.logo;
            txtDescription.EditValue = list.Description;
            cmbColour.EditValue = list.ColurId;
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
                //product.Name = txtName.EditValue.ToString();
                //product.CategoryId = (int)cmbCategoryName.EditValue;
                //product.CompanyId = (int)cmbSupplyerName.EditValue;
                //product.ReorderLebel = Convert.ToInt16(txtReorderLevel.EditValue);
                //product.PurchasePrice = Convert.ToDecimal(txtProductPrice.EditValue);
                //product.SellingPrice = Convert.ToDecimal(txtSellingPrice.EditValue);
                //product.VatPercent = Convert.ToDecimal(txtVat.EditValue);
                //product.logo = (byte[])pictureEdit1.EditValue;
                //product.Description = (string)txtDescription.EditValue;
                //product.Status = Connection.ValueCheck(chkActivation).ToString();
                //product.BrandId = Convert.ToInt16(cmbBrand.EditValue);
                //product.ColurId = (int)cmbColour.EditValue;
                //product.SizeId = (int)cmbSize.EditValue;
                ////DisCountPercent = Convert.ToDecimal(txtDiscountPercent.EditValue),
                //product.DisCountPercent = (decimal)txtDiscountPercent.EditValue;
                //product.CreateById = Settings.Default.UserName;

                {
                    Name = txtName.EditValue.ToString(),
                    CategoryId = (int)cmbCategoryName.EditValue,
                    CompanyId = (int)cmbSupplyerName.EditValue,
                    ReorderLebel = Convert.ToInt16(txtReorderLevel.EditValue),
                    PurchasePrice = Convert.ToDecimal(txtProductPrice.EditValue),
                    SellingPrice = Convert.ToDecimal(txtSellingPrice.EditValue),
                    VatPercent = Convert.ToDecimal(txtVat.EditValue),
                    logo = (byte[])pictureEdit1.EditValue,
                    Description = (string)txtDescription.EditValue,
                    Status =(bool)chkActivation.EditValue,
                    BrandId = Convert.ToInt16(cmbBrand.EditValue),
                    ColurId = Convert.ToInt16(cmbColour.EditValue),
                    SizeId = Convert.ToInt16(cmbSize.EditValue),
                    //DisCountPercent = Convert.ToDecimal(txtDiscountPercent.EditValue),
                    DisCountPercent = Convert.ToDecimal(txtDiscountPercent.EditValue),
                    CreateById = Settings.Default.UserName
                };
                baseRepository.Insert(product);
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Smart Shop Alert:- Product save successfully", "System Message", new[] { DialogResult.OK },
                  FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));
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
                PurchasePrice = Convert.ToDecimal(txtProductPrice.EditValue),
                SellingPrice = Convert.ToDecimal(txtSellingPrice.EditValue),
                VatPercent = Convert.ToDecimal(txtVat.EditValue),
                ReorderLebel = Convert.ToInt16(txtReorderLevel.EditValue),
                logo = (byte[])pictureEdit1.EditValue,
                Description = txtDescription.EditValue.ToString(),
                ProductCode = txtCode.EditValue.ToString(),
                Status =(bool) chkActivation.EditValue,
                BrandId = (int)cmbBrand.EditValue,
                ColurId = (int)cmbColour.EditValue,
                SizeId = (int)cmbSize.EditValue,
                DisCountPercent = Convert.ToDecimal(txtDiscountPercent.EditValue),
                CreateById = Settings.Default.LoginName
            });
            XtraMessageBox.Show("Smart Shop Alert:- Product update successfully");
        }
        
        private void OpenForm_FormClosed(object sender, FormClosedEventArgs e)
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
        }

        private void btnSupplyer_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    frmSupplyerEntry openForm = new frmSupplyerEntry
                    {
                        dbAccess = Command.DbCommand.Create,
                    };
                    openForm.FormClosed += OpenForm_FormClosed;
                    openForm.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Smart Shop Alert!:- Data Error", exception.Message);
            }
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    frmCategoriesSetupEntry openForm = new frmCategoriesSetupEntry
                    {
                        dbAccess = Command.DbCommand.Create,
                    };
                    openForm.FormClosed += OpenForm_FormClosed;
                    openForm.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Smart Shop Alert!:- Data Error", exception.Message);
            }
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    {
            //        frmbr openForm = new frmCategoriesSetupEntry
            //        {
            //            dbAccess = Command.DbCommand.Create,
            //        };
            //        openForm.FormClosed += OpenForm_FormClosed;
            //        openForm.ShowDialog();
            //    }
            //}
            //catch (Exception exception)
            //{
            //    XtraMessageBox.Show("Smart Shop Alert!:- Data Error", exception.Message);
            //}
        }
    }
}