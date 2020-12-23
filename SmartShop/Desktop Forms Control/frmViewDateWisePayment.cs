using SmartShop.Models;
using SmartShop.Repository;
using System;
using System.Linq;
using static SmartShop.Interface.DueCollection;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmViewDateWisePayment : DevExpress.XtraEditors.XtraForm
    {
        IDueRepository<ArrearCollection> _dueRepository = new DueCollectionRepository();
        public frmViewDateWisePayment()
        {
            InitializeComponent();
        }

        private void frmViewDateWisePayment_Load(object sender, System.EventArgs e)
        {
            txtDateF.EditValue = DateTime.Now.ToString("dd-MMM-yyyy");
            txtDateT.EditValue = DateTime.Now.ToString("dd-MMM-yyyy");
            gridControl1.DataSource = _dueRepository.GetDateWisePaymentView(txtDateF.EditValue.ToString(), txtDateT.EditValue.ToString()).ToList();
        }

        private void btnView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //txtDateF.EditValue = DateTime.Now.ToString("dd-MMM-yyyy");
            //txtDateT.EditValue = DateTime.Now.ToString("dd-MMM-yyyy");
            gridControl1.DataSource = _dueRepository.GetDateWisePaymentView(txtDateF.EditValue.ToString(), txtDateT.EditValue.ToString()).ToList();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //txtDateF.EditValue = DateTime.Now.ToString("dd-MMM-yyyy");
            // txtDateT.EditValue = DateTime.Now.ToString("dd-MMM-yyyy");
            gridControl1.DataSource = _dueRepository.GetDateWisePaymentView(txtDateF.EditValue.ToString(), txtDateT.EditValue.ToString()).ToList();
        }
    }
}