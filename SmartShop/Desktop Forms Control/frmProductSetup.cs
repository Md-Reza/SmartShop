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
using DevExpress.XtraSplashScreen;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Models;
using SmartShop.Repository;
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
        IBaseRepository<ProductName> baseRepository = new ProductNameRepository();
        IBaseRepository<UserLogin> useRepository = new UserLoginRepository();
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
                        code = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Code").ToString()
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
            SplashScreenManager.ShowForm(this,typeof(WaitForm1),useFadeIn:true,useFadeOut:true);
            gridControl1.DataSource = baseRepository.Get();
            SplashScreenManager.CloseForm();
        }
    }
}
