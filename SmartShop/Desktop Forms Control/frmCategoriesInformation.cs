using DevExpress.XtraEditors;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Windows.Forms;
using static SmartShop.Interface.Interface;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmCategoriesInformation : DevExpress.XtraEditors.XtraForm
    {
        IBaseRepository<CategoriesSetup> baseRepository = new CategoriesRepository();
        public frmCategoriesInformation()
        {
            InitializeComponent();
        }
        private void LoadGrid()
        {
            gridControl1.DataSource = baseRepository.Get();
        }
        private void OpenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadGrid();
        }
        private void frmCategoriesInformation_Load(object sender, EventArgs e)
        {
            // SplashScreenManager.ShowForm(this, typeof(WaitForm1), useFadeIn: true, useFadeOut: true);
            gridControl1.DataSource = baseRepository.Get();
            // SplashScreenManager.CloseForm();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount == 1)
            {
                frmCategoriesSetupEntry openForm = new frmCategoriesSetupEntry
                {
                    dbAccess = Command.DbCommand.Update,
                    categoriesName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CategoryName").ToString()
                };
                openForm.FormClosed += OpenForm_FormClosed;
                openForm.ShowDialog();
            }
            else
                XtraMessageBox.Show("Smart Shop Alert!:- Please Select a categories name");
        }
    }
}