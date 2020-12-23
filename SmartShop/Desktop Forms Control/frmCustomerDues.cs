using DevExpress.XtraEditors;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.CustomerInfoInterface;
using static SmartShop.Interface.DueCollection;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmCustomerDues : DevExpress.XtraEditors.XtraForm
    {
        IDueRepository<ArrearCollection> _dueRepository = new DueCollectionRepository();
        ICustRepository<CustomerInformation> _custRepository = new CustomersRepository();
        public string custId;
        public frmCustomerDues()
        {
            InitializeComponent();
        }
        private void LoadAllDues()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = _dueRepository.GetAllCustomerArrear().ToList();
        }

        private void frmCustomerDues_Load(object sender, System.EventArgs e)
        {
            txtDateF.EditValue = DateTime.Now;
            txtDateT.EditValue = DateTime.Now;
            LoadAllDues();
            LoadCustomer();
        }

        private void btnCollection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                {
                    frmDueCollection openForm = new frmDueCollection
                    {
                        dbAccess = Command.DbCommand.Create,
                        custId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, CustId).ToString()
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

        private void OpenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadAllDues();
            LoadCustomer();
        }

        private void btnRefresh2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl2.DataSource = _dueRepository.GetDateWisePaymentView(txtDateF.EditValue.ToString(), txtDateT.EditValue.ToString()).ToList();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gridView1.SelectedRowsCount == 1)
                {
                    frmCustomerEntry openForm = new frmCustomerEntry
                    {
                        dbAccess = Command.DbCommand.Update,
                        custId = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, CustId).ToString()
                    };
                    openForm.FormClosed += OpenForm_FormClosed;
                    openForm.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Smart Shop Alert..!:- Please select one customer for update");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Smart Shop Alert!:- Data Error please select atleast one customer.", exception.Message);
            }
        }

        private void BtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnRefresh3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadCustomer();
        }

        private void LoadCustomer()
        {
            var custList = _custRepository.GetAllCustomer();
            gridControl3.DataSource = null;
            gridControl3.DataSource = custList.ToList();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadAllDues();
        }
    }
}