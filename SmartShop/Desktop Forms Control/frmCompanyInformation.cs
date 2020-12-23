using DevExpress.XtraEditors;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmCompanyInformation : DevExpress.XtraEditors.XtraForm
    {
        ComapnySetupRepository comapnySetupRepository = new ComapnySetupRepository();

        public frmCompanyInformation()
        {
            InitializeComponent();
        }

        private void frmCompanyInformation_Load(object sender, EventArgs e)
        {
            var list = comapnySetupRepository.Get();
            gridControl1.DataSource = list.ToList();
        }

        private void OpenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var list = comapnySetupRepository.Get();
            gridControl1.DataSource = list.ToList();
        }

        private void barBtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                {
                    frmOfficeEntry openForm = new frmOfficeEntry
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

        private void barBtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount == 1)
            {
                frmOfficeEntry openForm = new frmOfficeEntry
                {
                    dbAccess = Command.DbCommand.Update,
                    Name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, Name).ToString(),
                };
                openForm.FormClosed += OpenForm_FormClosed;
                openForm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Please select at least one cut program for auto cutting.");

            }
        }
    }
}