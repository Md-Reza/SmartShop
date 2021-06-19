using DevExpress.XtraEditors;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Models;
using SmartShop.Repository;
using SmartShop.SmartReports;
using System;
using System.Windows.Forms;
using static SmartShop.Interface.Interface;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmProductSetup : DevExpress.XtraEditors.XtraForm
    {
        public Command.DbCommand dbAccess;
        public frmProductSetup()
        {
            InitializeComponent();
            layoutControl1.AllowCustomization = false;
        }
        IBaseRepository<Products> baseRepository = new ProductNameRepository();
        private void OpenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadGrid();
        }
        public void LoadGrid()
        {
            gridControl1.DataSource = baseRepository.Get();
        }

        private void btnAdd_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                {
                    frmProductNameEntry openForm = new frmProductNameEntry
                    {
                        dbAccess = Command.DbCommand.Create,
                    };
                    openForm.FormClosed += OpenForm_FormClosed;
                    openForm.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Smart Shop Alert!:- Data Error" + exception);
            }
        }

        private void btnEdit_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gridView1.SelectedRowsCount == 1)
                {
                    frmProductNameEntry openForm = new frmProductNameEntry
                    {
                        dbAccess = Command.DbCommand.Update,
                        code = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductCode").ToString()
                    };
                    openForm.FormClosed += OpenForm_FormClosed;
                    openForm.ShowDialog();
                }
                else
                    XtraMessageBox.Show("Smart Shop Alert !:- Please Select a product name");
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message);
            }
        }

        private void frmProductSetup_Load(object sender, EventArgs e)
        {
            //SplashScreenManager.ShowForm(this,typeof(WaitForm1),useFadeIn:true,useFadeOut:true);
            gridControl1.DataSource = baseRepository.Get();
            ///SplashScreenManager.CloseForm();
        }

        private void layoutControlGroup2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Customize")
                gridView1.ColumnsCustomization();
            else
                gridView1.DestroyCustomization();
        }

        private void btnBarcode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportViewer openForm = new ReportViewer("Report_9", Command.SettingValue.NotApplicable.ToString())
            {
                // KeyFieldCode = date
            };
            openForm.ShowDialog();
        }
    }
}
