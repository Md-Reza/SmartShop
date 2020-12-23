using DevExpress.DataAccess.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using SmartShop.Dtos;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmPurchaseEntryByFile : DevExpress.XtraEditors.XtraForm
    {
        GetByAllSequence _getByAllSequence = new GetByAllSequence();
        ProductNameRepository _productNameRepository = new ProductNameRepository();
        PurchaseRepository purchaseRepository = new PurchaseRepository();
        public frmPurchaseEntryByFile()
        {
            InitializeComponent();
            //Voice.Speech("Attention Please," +
            //             "A1 Line efficiency dropped by 10%, " +
            //             "B1 Line efficiency dropped by 10%, " +
            //             "C1 Line efficiency dropped by 20%, " +
            //             "D1 Line efficiency dropped by 30%, " +
            //             "A2 Line efficiency dropped by 2%, " +
            //             "B2 Line efficiency dropped by 5%, " +
            //             "C2 Line efficiency dropped by 20%, " +
            //             "D2 Line efficiency dropped by30%,  " +
            //             "Attention Please, " +
            //             " A1 Line input delay, Please add more bundles");
        }

        private void btnFileUpload_Click(object sender, EventArgs e)
        {
            if (cmbSupplyer.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $"Please select suppler.");
                return;
            }
            if (txtCompanyInvoice.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $"Please input company invoice.");
                return;
            }
            if (txtDelivaryBy.EditValue == null)
            {
                Console.Beep(5000, 800);
                XtraMessageBox.Show(this, $"Please input delivery by .");
                return;
            }

            OnLoadGridClear();
            DialogResult result = OpenFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;

            btnFileUpload.EditValue = OpenFileDialog.FileName;
            ProcessUploadedFile(OpenFileDialog.FileName);
        }

        private void OnLoadGridClear()
        {
            ExcelDataSource excelDataSource = new ExcelDataSource
            {
                SourceOptions = new CsvSourceOptions
                {
                    UseFirstRowAsHeader = true,
                    SkipEmptyRows = true
                }
            };
            excelDataSource.SourceOptions.UseFirstRowAsHeader = true;
            excelDataSource.SourceOptions.SkipEmptyRows = true;
            excelDataSource.SourceOptions.UseFirstRowAsHeader = true;
            excelDataSource.Fill();
            if (excelDataSource.GetService(typeof(IExcelSchemaProvider)) is IExcelSchemaProvider schemaProvider)
            {
                gridView1.Columns.Clear();
            }
            chkInvoice.UnCheckAll();
        }
        private void ProcessUploadedFile(string fileName)
        {
            ExcelDataSource excelDataSource = new ExcelDataSource
            {
                FileName = fileName,
                SourceOptions = new CsvSourceOptions
                {
                    UseFirstRowAsHeader = true,
                    SkipEmptyRows = true
                }
            };
            excelDataSource.Fill();
            gridControl1.DataSource = excelDataSource;
            btnSave.Enabled = true;
        }

        private void btnFileUpload_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DialogResult result = OpenFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;

            btnFileUpload.EditValue = OpenFileDialog.FileName;
            ProcessUploadedFile(OpenFileDialog.FileName);
            btnSave.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cmbSupplyer.EditValue = null;
            btnFileUpload.EditValue = null;
            gridControl1.DataSource = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
            gridView1.RefreshData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DbOperation();
        }
        public void DbOperation()
        {
            if (!ValidationProvider.Validate()) return;
            if (gridView1.RowCount >= 1)
            {
                List<PurchaseChild> purchaseChild = new List<PurchaseChild>();

                PurchaseParent purchaseParent = new PurchaseParent()
                {
                    PurchaseDate = Convert.ToDateTime(txtPurchaseDate.EditValue),
                    SalesMonth = Convert.ToDateTime(txtPurchaseDate.EditValue).ToString("yyyyMM"),
                    PurchaseInvoice = txtInvoice.EditValue.ToString(),
                    CompanyInvoice = txtCompanyInvoice.EditValue.ToString(),
                    SupplyerId = cmbSupplyer.EditValue.ToString(),
                    DelivaryBy = txtDelivaryBy.EditValue.ToString(),
                    CreateBy = Settings.Default.UserName,
                    CreateDate = DateTime.Now,
                    PcName = txtComputerName.EditValue.ToString()
                };

                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    purchaseChild.Add(new PurchaseChild()
                    {
                        PurchaseInvoice = txtInvoice.EditValue.ToString(),
                        ProductCode = gridView1.GetRowCellValue(i, "ProductCode").ToString(),
                        SalesMonth = Convert.ToDateTime(txtPurchaseDate.EditValue).ToString("yyyyMM"),
                        Qty = Convert.ToInt16(gridView1.GetRowCellValue(i, "Qty")),
                        ProductPrice = Convert.ToInt16(gridView1.GetRowCellValue(i, "ProductPrice")),
                        SellingPrice = Convert.ToInt16(gridView1.GetRowCellValue(i, "SellingPrice")),
                        DiscountPrice = Convert.ToInt16(gridView1.GetRowCellValue(i, "DiscountPrice") == null ? 0 : gridView1.GetRowCellValue(i, "DiscountPrice")),
                        DiscountAmount = Convert.ToInt16(gridView1.GetRowCellValue(i, "DiscountPrice") == null ? 0 : gridView1.GetRowCellValue(i, "DiscountAmount")),
                        TotalAmount = Convert.ToInt16(gridView1.GetRowCellValue(i, "Qty")) * Convert.ToInt16(gridView1.GetRowCellValue(i, "ProductPrice")),
                        SizeId = Convert.ToInt16(gridView1.GetRowCellValue(i, "SizeId") == null ? null : gridView1.GetRowCellValue(i, "SizeId")),
                        ColourId = Convert.ToInt16(gridView1.GetRowCellValue(i, "ColourId") == null ? 0 : gridView1.GetRowCellValue(i, "ColourId")),
                        BrandId = Convert.ToInt16(gridView1.GetRowCellValue(i, "BrandId") == null ? 0 : gridView1.GetRowCellValue(i, "BrandId")),
                    });
                }
                PurchaseCreateDto purchaseCreateDto = new PurchaseCreateDto()
                {
                    purchaseParent = purchaseParent,
                    purchaseChild = purchaseChild
                };

                purchaseRepository.InsertPurchaseData(purchaseCreateDto);
                purchaseRepository.InsertPurchaseChild(purchaseChild);

                XtraMessageBox.Show("Purchase save successfully");
                txtInvoice.EditValue = _getByAllSequence.GetByAll().Where(f => f.Code == "Invoice").FirstOrDefault().StartWith;
                gridControl2.DataSource = purchaseRepository.GetByLastPurchase(txtPurchaseDate.EditValue.ToString());
                GridClear();
                LoadInvoice();
            }
            else
            {
                Voice.Speech("Can't performed save into database");
                Console.Beep(5000, 800);
                XtraMessageBox.Show("Can't performed save into database");
            }
        }

        private void frmPurchaseEntryByFile_Load(object sender, EventArgs e)
        {
            layoutControl1.AllowCustomization = false;
            // SplashScreenManager.ShowForm(this, typeof(WaitForm1), useFadeIn: true, useFadeOut: true);
            txtPurchaseDate.EditValue = DateTime.Now;
            txtInvoice.EditValue = _getByAllSequence.GetByAll().Where(f => f.Code == "Invoice").FirstOrDefault().StartWith;
            txtUserName.EditValue = Settings.Default.UserName;
            txtComputerName.EditValue = Dns.GetHostName();
            btnSave.Enabled = false;
            txtPurchaseDate.EditValue = DateTime.Now;
            LoadSupplyer();
            LoadInvoice();
            gridControl2.DataSource = purchaseRepository.GetByLastPurchase(txtPurchaseDate.EditValue.ToString());
            //SplashScreenManager.CloseForm();
        }
        private void LoadInvoice()
        {
            var date = txtPurchaseDate.DateTime.AddDays(-5).ToString();

            chkInvoice.DataSource = purchaseRepository.GetByAllInvoice(date).ToList();
            chkInvoice.DisplayMember = "PurchaseInvoice";
            chkInvoice.ValueMember = "PurchaseInvoice";
            chkInvoice.SelectedValue = "PurchaseInvoice";
        }

        private void LoadSupplyer()
        {
            cmbSupplyer.Properties.DataSource = _productNameRepository.GetAllSupplyerInformations().ToList();
            cmbSupplyer.Properties.DisplayMember = "SupplyerName";
            cmbSupplyer.Properties.ValueMember = "Id";
        }

        private void LoadByInvoice(string invoice)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), useFadeIn: true, useFadeOut: true);
            invoice = chkInvoice.CheckedItems[0].ToString();
            var list = purchaseRepository.GetByInvoice(invoice);
            if (list.Any())
            {
                gridControl1.DataSource = list.ToList().Select(f => new
                {
                    f.ProductCode,
                    f.Qty,
                    f.ProductPrice,
                    f.SellingPrice,
                    f.DiscountPrice,
                    f.DiscountAmount,
                    f.TotalAmount
                });
            }
            btnSave.Enabled = false;
            SplashScreenManager.CloseForm();
        }

        private void GridClear()
        {
            ExcelDataSource excelDataSource = new ExcelDataSource
            {
                SourceOptions = new CsvSourceOptions
                {
                    UseFirstRowAsHeader = true,
                    SkipEmptyRows = true
                }
            };
            excelDataSource.SourceOptions.UseFirstRowAsHeader = true;
            excelDataSource.SourceOptions.SkipEmptyRows = true;
            excelDataSource.SourceOptions.UseFirstRowAsHeader = true;
            excelDataSource.Fill();
            if (excelDataSource.GetService(typeof(IExcelSchemaProvider)) is IExcelSchemaProvider schemaProvider)
            {
                gridView1.Columns.Clear();
            }

            txtDelivaryBy.EditValue = null;
            txtCompanyInvoice.EditValue = null;
            btnFileUpload.EditValue = null;
        }

        private void chkInvoice_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (chkInvoice.CheckedItems.Count == 1)
            {
                string invoiceList = null;
                btnSave.Enabled = false;
                invoiceList = chkInvoice.CheckedItems[0].ToString();
                if (!string.IsNullOrEmpty(invoiceList)) LoadByInvoice(invoiceList);
                else return;
            }
            else return;
        }

        private void chkInvoice_Click(object sender, EventArgs e)
        {
            chkInvoice.UnCheckAll();
            chkInvoice.CheckOnClick = true;
        }

        private void chkInvoice_DoubleClick(object sender, EventArgs e)
        {
            chkInvoice.UnCheckAll();
            chkInvoice.CheckOnClick = true;
        }

        private void btnBarcodePrint_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Under Construction");
        }
    }
}