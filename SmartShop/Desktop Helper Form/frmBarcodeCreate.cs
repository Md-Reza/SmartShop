using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using SmartShop.Models;
using SmartShop.Repository;
using SmartShop.SmartReports;
using System;
using System.Collections.Generic;
using static SmartShop.Interface.Interface;
using System.Windows.Forms;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmBarcodeCreate : DevExpress.XtraEditors.XtraForm
    {
        IBaseRepository<Products> baseRepository = new ProductNameRepository();
        public frmBarcodeCreate()
        {
            InitializeComponent();
        }
        public void LoadGrid()
        {
            gridControl1.DataSource = baseRepository.Get();
        }

        private void frmBarcodeCreate_Load(object sender, System.EventArgs e)
        {
            LoadGrid();
        }
        private void btnProcess_Click(object sender, System.EventArgs e)
        {
            List<Products> productNames = new List<Products>();
            int[] selectedRowHandles = gridView1.GetSelectedRows();
            int Count = Convert.ToInt16(txtBarcodeNo.EditValue);
            if (gridView1.SelectedRowsCount > 0)
            {
                try
                {
                    foreach (var items in selectedRowHandles)
                    {
                        for (int i = 0; i < Count; i++)
                        {
                            productNames.Add(new Products()
                            {
                                ProductCode = gridView1.GetRowCellValue(items, ProductCode).ToString(),
                                SellingPrice = Convert.ToDecimal(gridView1.GetRowCellValue(items, SellingPrice))
                            });
                        }
                    }
                    rptBarcodeListPrint Report_1 = new rptBarcodeListPrint()
                    {
                        DataSource = productNames
                    };
                    Report_1.ShowPreview();
                }
                catch (Exception exception)
                {
                    XtraMessageBox.Show(exception.Message.ToString());
                }
            }
            else
            {
                XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Please select at least one product to create barcode", "System Message", new[] { DialogResult.OK },
                    FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationRed()));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}