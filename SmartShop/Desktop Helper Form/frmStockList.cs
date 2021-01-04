using System;
using System.Drawing;
using SmartShop.Models;
using SmartShop.Repository;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using SmartShop.SmartReports;
using static SmartShop.Interface.Interface;
using static SmartShop.Interface.StockList;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmStockList : DevExpress.XtraEditors.XtraForm
    {
        private string gridGuid = null;
        IStockList<Stock> stock = new StockRepository();
        IBaseRepository<CategoriesSetup> categoryRepository = new CategoriesRepository();
        public frmStockList()
        {
            InitializeComponent();
        }

        private void StockList()
        {
            gridControl1.DataSource = stock.GetAllStockList().ToList();
        }

        private void CategoryLoad()
        {
            var category = categoryRepository.Get().ToList();
            repocmbCategory.DataSource = category.ToList();
            repocmbCategory.DisplayMember = "CategoryName";
            repocmbCategory.ValueMember = "id";
        }

        private void frmStockList_Load(object sender, System.EventArgs e)
        {
            CategoryLoad();
            StockList();
            gridGuid = FileControl.SaveGridLayout(gridView1);
        }

        private void btnView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cmbCategory.EditValue==null)
            {
                gridControl1.DataSource = null;
                XtraMessageBox.Show("Please select one category");
                return;
            }
            if (cmbCategory.EditValue != null)
            {
                gridControl1.DataSource = stock.GetAllStockListBySupllyer(cmbCategory.EditValue.ToString()).ToList();
            }
            else
                StockList();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cmbCategory.EditValue = null;
            StockList();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "QtyBalance")
            {
                int value = Convert.ToInt32(currentView.GetRowCellValue(e.RowHandle, QtyBalance));
                if (value < 0)
                    e.Appearance.BackColor = Color.Red;
            }
            if (e.Column.FieldName == "QtyBalance")
            {
                int value = Convert.ToInt32(currentView.GetRowCellValue(e.RowHandle, QtyBalance));
                if (value >= 0 && value <= 5)
                    e.Appearance.BackColor = Color.Red;
            }
            if (e.Column.FieldName == "QtyBalance")
            {
                int value = Convert.ToInt32(currentView.GetRowCellValue(e.RowHandle, QtyBalance));
                if (value >= 6 && value <= 10)
                    e.Appearance.BackColor = Color.Turquoise;
            }
            if (e.Column.FieldName == "QtyBalance")
            {
                int value = Convert.ToInt32(currentView.GetRowCellValue(e.RowHandle, QtyBalance));
                if (value >= 16 )
                    e.Appearance.BackColor = Color.LimeGreen;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportViewer openForm = new ReportViewer("Report_2", Command.SettingValue.NotApplicable.ToString());
            openForm.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportViewer openForm = new ReportViewer("Report_2", Command.SettingValue.NotApplicable.ToString());
            openForm.ShowDialog();
        }

        private void layoutControlGroup2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Customize")
            {
                if (gridView1.CustomizationForm == null)
                    gridView1.ShowCustomization();
                else
                    gridView1.DestroyCustomization();
            }
            else if (e.Button.Properties.Caption == "Reset")
            {
                if (gridView1.CustomizationForm != null)
                    gridView1.DestroyCustomization();
                FileControl.RestoreGridLayout(gridView1, gridGuid);
            }
            else if (e.Button.Properties.Caption == "Export")
            {

                DialogResult pathSelected = SaveFileDialog.ShowDialog();
                if (pathSelected == DialogResult.OK)
                    FileControl.ExportGrid(gridView1, SaveFileDialog.FileName);

            }

        }
    }
}