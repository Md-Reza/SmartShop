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
using DevExpress.DataAccess.Excel;
using DevExpress.Xpf.LayoutControl;
using SmartShop.Dtos;
using SmartShop.Models;
using SmartShop.Properties;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmPurchaseEntryByFile : DevExpress.XtraEditors.XtraForm
    {
        public frmPurchaseEntryByFile()
        {
            InitializeComponent();
        }

        private void btnFileUpload_Click(object sender, EventArgs e)
        {
            DialogResult result = OpenFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;

            btnFileUpload.EditValue = OpenFileDialog.FileName;
            ProcessUploadedFile(OpenFileDialog.FileName);
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
        }

        private void btnFileUpload_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DialogResult result = OpenFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;

            btnFileUpload.EditValue = OpenFileDialog.FileName;
            ProcessUploadedFile(OpenFileDialog.FileName);
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
                        Qty = Convert.ToInt16(gridView1.GetRowCellValue(i, "Qty")),
                        ProductPrice = Convert.ToInt16(gridView1.GetRowCellValue(i, "ProductPrice")),
                        SellingPrice = Convert.ToInt16(gridView1.GetRowCellValue(i, "SellingPrice")),
                        DiscountPrice = Convert.ToInt16(gridView1.GetRowCellValue(i, "DiscountPrice") == null ? 0 : gridView1.GetRowCellValue(i, "DiscountPrice")),
                        DiscountAmount = Convert.ToInt16(gridView1.GetRowCellValue(i, "DiscountPrice") == null ? 0 : gridView1.GetRowCellValue(i, "DiscountAmount")),
                        TotalAmount = Convert.ToInt16(gridView1.GetRowCellValue(i, "Qty")) * Convert.ToInt16(gridView1.GetRowCellValue(i, "ProductPrice"))
                    });
                }
                PurchaseCreateDto purchaseCreateDto = new PurchaseCreateDto()
                {
                    purchaseParent = purchaseParent,
                    purchaseChil = purchaseChild
                };

                Voice.Speech("Purchase save successfully");
                XtraMessageBox.Show("Purchase save successfully");
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
            txtPurchaseDate.EditValue = DateTime.Now;
        }
    }
}