using DevExpress.XtraEditors;
using SmartShop.Desktop_Helper_Form;
using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Linq;
using System.Windows.Forms;
using static SmartShop.Interface.CustomerInfoInterface;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmCustomerInformation : DevExpress.XtraEditors.XtraForm
    {
        ICustRepository<CustomerInformation> _custRepository = new CustomersRepository();
        public frmCustomerInformation()
        {
            InitializeComponent();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                {
                    frmCustomerEntry openForm = new frmCustomerEntry
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

        private void OpenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadAllCustomers();
        }

        private void LoadAllCustomers()
        {
            var custList = _custRepository.GetAllCustomer();
            gridControl1.DataSource = custList.ToList();
        }

        private void frmCustomerInformation_Load(object sender, EventArgs e)
        {
            LoadAllCustomers();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                XtraMessageBox.Show("Smart Shop Alert!:- Data Error", exception.Message);
            }
        }
    }
}