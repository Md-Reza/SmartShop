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
using DevExpress.XtraWaitForm;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Repository;
using SmartShop.Models;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmSupplyerInformations : DevExpress.XtraEditors.XtraForm
    {
        SupplyerInformationRepository baseRepository = new SupplyerInformationRepository();
        SupplyerInformationRepository comapnySetupRepository = new SupplyerInformationRepository();
        public Command.DbCommand dbAccess;
        public frmSupplyerInformations()
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

        private void frmSupplyerInformations_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), useFadeIn: true, useFadeOut: true);
            gridControl1.DataSource = baseRepository.Get();
            SplashScreenManager.CloseForm();
        }


        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm();
            LoadGrid();
            SplashScreenManager.CloseForm();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount == 1)
            {
                frmSupplyerEntry openForm = new frmSupplyerEntry
                {
                    dbAccess = Command.DbCommand.Update,
                    supplyerName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SupplyerName").ToString()
                };
                openForm.FormClosed += OpenForm_FormClosed;
                openForm.ShowDialog();
            }
            else
                XtraMessageBox.Show("Smart Shop Alert!:- Please Select a suppler name ");
        }

        private void btnCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                XtraMessageBox.Show("Smart Shop Alert!:- Data Error");
            }
        }
    }
}
