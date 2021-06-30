using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using SmartShop.Repository;
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
        public frmOrderCompletion()
        {
            InitializeComponent();
        }

        private void frmOrderCompletion_Load(object sender, EventArgs e)
        {
            var allData = _sellsRepository.GetAllSales();
            foreach (var item in allData)
            {
                LayoutControlItem layoutControlItem = layoutControlGroup2.AddItem();
                
                layoutControlItem.SizeConstraintsType = SizeConstraintsType.Custom;
                layoutControlItem.MaxSize = new System.Drawing.Size(250, 100);
                layoutControlItem.MinSize = new System.Drawing.Size(250, 150);
                MemoEdit memoEdit = new MemoEdit
                {
                    Text ="Invoice: "+item.SellsInvoice
                    + "\r\n" + "Name: "+ item.ProductCode
                    + "\r\n" + "Qty. " +item.Qty
                    + "\r\n" +"Vat."+item.VatAmount 
                    + "\r\n" +"Dis Amount. "+item.DiscountAmount
                    + "\r\n" +"Amount: " +item.TotalAmount,
                    BackColor=Color.White,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ReadOnly=true
                };
                memoEdit.Properties.ScrollBars=ScrollBars.None;
                layoutControlItem.Control = memoEdit;
                //ListBox listBox = new ListBox();
             
                    
                //listBox.Items.Add(Text= "Invoice: " + item.SellsInvoice
                //     + "\r\n" + "Name: " + item.ProductCode
                //     + "\r\n" + "Qty. " + item.Qty
                //     + "\r\n" + "Vat." + item.VatAmount
                //     + "\r\n" + "Dis Amount. " + item.DiscountAmount
                //     + "\r\n" + "Amount: " + item.TotalAmount);
                //layoutControlItem2.Control = listBox;
            }
            
        }
    }
}