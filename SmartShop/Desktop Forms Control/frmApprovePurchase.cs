using SmartShop.Repository;
using System;
using System.Data;
using System.Linq;

namespace SmartShop.Desktop_Forms_Control
{
    public partial class frmApprovePurchase : DevExpress.XtraEditors.XtraForm
    {
        PurchaseRepository purchaseRepository = new PurchaseRepository();
        public frmApprovePurchase()
        {
            InitializeComponent();
        }

        private void frmApprovePurchase_Load(object sender, EventArgs e)
        {
            LoadInvoice();
           
        }
        private void LoadInvoice()
        {
           // chkInvoiceList.DataSource = purchaseRepository.GetByAllInvoice().ToList();
            chkInvoiceList.DisplayMember = "PurchaseInvoice";
            chkInvoiceList.ValueMember = "PurchaseInvoice";
            chkInvoiceList.SelectedValue = "PurchaseInvoice";
        }
        private void LoadByInvoice(string invoice)
        {
            invoice = chkInvoiceList.CheckedItems[0].ToString();
            var list = purchaseRepository.GetByInvoiceApprove(invoice);
            if (list.Any())
            {
                gridControl1.DataSource = null;
                gridControl1.DataSource = list.ToList().Select(f => new
                {
                    f.PChidId,
                    f.ProductCode,
                    f.PurchaseInvoice,
                    f.PurchasePrice,
                    f.Qty,
                    f.ProductPrice,
                    f.SellingPrice,
                    f.DiscountPrice,
                    f.DiscountAmount,
                    f.TotalAmount
                });
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkInvoiceList_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (chkInvoiceList.CheckedItems.Count == 1)
            {
                string invoiceList = null;
                btnSave.Enabled = false;
                invoiceList = chkInvoiceList.CheckedItems[0].ToString();
                if (!string.IsNullOrEmpty(invoiceList)) LoadByInvoice(invoiceList);
                else return;
            }
            else return;
        }

        private void chkInvoiceList_DoubleClick(object sender, EventArgs e)
        {
            chkInvoiceList.UnCheckAll();
            chkInvoiceList.CheckOnClick = true;
        }

        private void chkInvoiceList_Click(object sender, EventArgs e)
        {
            chkInvoiceList.UnCheckAll();
            chkInvoiceList.CheckOnClick = true;
        }
    }
}