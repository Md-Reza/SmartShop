using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using SmartShop.Models;
using SmartShop.Properties;
using SmartShop.Repository;
using SmartShop.SmartReports;
using System;
using System.Drawing;
using System.Windows.Forms;
using static SmartShop.Interface.MonthSummaryInterface;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmMonthWiseStock : DevExpress.XtraEditors.XtraForm
    {
        IMonthSummary<MonthSummary> monthSummary = new MonthSummaryRepository();
        private string gridGuid = null;
        public frmMonthWiseStock()
        {
            InitializeComponent();
        }
        private void btnProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), useFadeIn: true, useFadeOut: true);
            var SalesMonth = txtMonth.EditValue.ToString();
            Settings.Default.SalesMonth = SalesMonth;
            monthSummary.ExecuteMonthSummaryEntry(SalesMonth);

            XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Month wise stock listing process successfully", "System Message", new[] { DialogResult.OK },
                  FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.SuccessfullGreen()));

            gridControl1.DataSource = monthSummary.GetByMonthWiseStock(SalesMonth);
            layoutControlGroup2.Text = $@"Reports on month summary( { Settings.Default.SalesMonth}) ";
            SplashScreenManager.CloseForm();
        }

        private void frmMonthWiseStock_Load(object sender, EventArgs e)
        {
            txtMonth.EditValue = DateTime.Now.ToString("yyyyMM");
            var SalesMonth = txtMonth.EditValue.ToString();
            Settings.Default.SalesMonth = SalesMonth;
            gridGuid = FileControl.SaveGridLayout(gridView1);
        }

        private void btnView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            layoutControlGroup1.Text = $@"Reports on month summary( { Settings.Default.SalesMonth}) ";
            layoutControlGroup2.Text = $@"Reports on month summary( { Settings.Default.SalesMonth}) ";
            var SalesMonth = txtMonth.EditValue.ToString();
            Settings.Default.SalesMonth = SalesMonth;
            gridControl1.DataSource = null;
            gridControl1.DataSource = monthSummary.GetByMonthWiseStock(Settings.Default.SalesMonth);
           
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView currentView = sender as GridView;
            if (e.Column.FieldName == "PurchaseQty")
            {
                var value = Convert.ToInt32(currentView.GetRowCellValue(e.RowHandle, PurchaseQty));
                if (value <= 0)
                    e.Appearance.BackColor = Color.Red;
            }
            if (e.Column.FieldName == "ProfitAmount")
            {
                var value = Convert.ToInt32(currentView.GetRowCellValue(e.RowHandle, ProfitAmount));
                if (value <= 500)
                    e.Appearance.BackColor = Color.Red;
            }

            if (e.Column.FieldName == "SalesQty")
            {
                var value = Convert.ToInt32(currentView.GetRowCellValue(e.RowHandle, SalesQty));
                if (value < 0)
                    e.Appearance.BackColor = Color.Red;
            }

            if (e.Column.FieldName == "SalesQty")
            {
                int value = Convert.ToInt32(currentView.GetRowCellValue(e.RowHandle, SalesQty));
                if (value >= 0 && value <= 5)
                    e.Appearance.BackColor = Color.Red;
            }
            if (e.Column.FieldName == "SalesQty")
            {
                int value = Convert.ToInt32(currentView.GetRowCellValue(e.RowHandle, SalesQty));
                if (value >= 6 && value <= 10)
                    e.Appearance.BackColor = Color.Turquoise;
            }
            if (e.Column.FieldName == "SalesQty")
            {
                int value = Convert.ToInt32(currentView.GetRowCellValue(e.RowHandle, SalesQty));
                if (value >= 16)
                    e.Appearance.BackColor = Color.LimeGreen;
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = XtraMessageBox.Show(FormsHelper.FormsHelperMessageBox.Show(this, "Are you want to see stock details press Yes. or see summary No.?", "Smart Shop Alert! *?", new[] { DialogResult.Yes, DialogResult.No },
                FormsHelper.FormsHelperMessageBox.SFMessageBoxIcon.InformationBlue()));
            if (result == DialogResult.Yes)
            {
                ReportViewer openForm = new ReportViewer("Report_10", Command.SettingValue.NotApplicable.ToString())
                {
                    KeyFieldCode = Settings.Default.SalesMonth
                };
                openForm.ShowDialog();
            }
            else if (result == DialogResult.No)
            {
                ReportViewer openForm = new ReportViewer("Report_2", Command.SettingValue.NotApplicable.ToString());
                openForm.ShowDialog();
            }

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
