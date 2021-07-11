using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraReports.UI;
using PagedList;
using SmartShop.FormsHelper;
using SmartShop.Models;
using SmartShop.Repository;
using SmartShop.SmartReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmOrderCompletion : DevExpress.XtraEditors.XtraForm
    {
        SellsRepository _sellsRepository = new SellsRepository();
        rptPosInvoice rptPosInvoice = new rptPosInvoice();
        int pageNumber = 1;
        IPagedList<SellesChild>pageList;
        public frmOrderCompletion()
        {
            InitializeComponent();
        }

        public async Task<IPagedList<SellesChild>> GetAllPendingOrder(int pageNumber=1,int pageSize = 10)
        {
            return await Task.Factory.StartNew(() => _sellsRepository.GetAllSales().ToPagedList(pageNumber, pageSize));
        }
        private async void frmOrderCompletion_Load(object sender, EventArgs e)
        {
            Designer.InitLayoutGroup(layoutControlGroup2, "Order List");
            pageList = await GetAllPendingOrder();
            btnNext.Enabled = pageList.HasNextPage;
            btnPrevious.Enabled = pageList.HasPreviousPage;
            //var allData = _sellsRepository.GetAllSales();
            gridControl1.DataSource = pageList.ToList();
            label1.Text = string.Format("Page {0}/{1}", pageNumber, pageList.PageCount);
        }

        private void repositoryOperationItem_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            documentViewer2.RequestDocumentCreation = true;
            ButtonEdit editor = (ButtonEdit)sender;
            int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            List<SellesChild> sellesChild = new List<SellesChild>();
            if (buttonIndex == 1)
            {
                XtraMessageBox.Show("Approved");
            }
            else if (buttonIndex == 2)
            {
                var invoice = _sellsRepository.GetAllPendingSales(Convert.ToInt64(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, SellsInvoice)));
                sellesChild.Clear();

                foreach (var item in invoice)
                {
                    sellesChild.Add(new SellesChild()
                    {
                        ProductCode = item.ProductCode,
                        SellingPrice = item.SellingPrice,
                        SellsInvoice = item.SellsInvoice,
                        Name = item.Products.ProductName,
                        Qty = item.Qty,
                        VatAmount = item.VatAmount,
                        DiscountAmount = item.DiscountAmount,
                        TotalAmount = item.TotalAmount
                    });
                }
                rptPosInvoice.DataSource = sellesChild;
                documentViewer2.DocumentSource = rptPosInvoice;
                documentViewer2.InitiateDocumentCreation();

            }
            else if (buttonIndex == 3)
            {
                XtraMessageBox.Show("Deleted");
            }
            else if (buttonIndex == 0)
            {
                XtraMessageBox.Show("Edited");
            }
        }

        private void layoutControlGroup4_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            rptPosInvoice.Print();
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage)
            {
                pageList = await GetAllPendingOrder(++pageNumber);
                btnNext.Enabled = pageList.HasNextPage;
                btnPrevious.Enabled = pageList.HasPreviousPage;
                gridControl1.DataSource = pageList.ToList();
                label1.Text = string.Format("Page {0}/{1}", pageNumber, pageList.PageCount);
            }
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage)
            {
                pageList = await GetAllPendingOrder(--pageNumber);
                btnNext.Enabled = pageList.HasNextPage;
                btnPrevious.Enabled = pageList.HasPreviousPage;
                gridControl1.DataSource = pageList.ToList();
                label1.Text = string.Format("Page {0}/{1}", pageNumber, pageList.PageCount);
            }
        }
    }
}