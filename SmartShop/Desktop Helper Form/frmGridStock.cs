using DevExpress.XtraEditors;
using SmartShop.Models;
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
using static SmartShop.Interface.StockList;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmGridStock : DevExpress.XtraEditors.XtraForm
    {
        IStockList<Stock> stock = new StockRepository();
        public frmGridStock()
        {
            InitializeComponent();
            var stockList = stock.GetAllStockList().ToList();
            gridControl1.DataSource = null;
            gridControl1.DataSource = stockList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var stockList = stock.GetAllStockList().ToList();
            gridControl1.DataSource = null;
            gridControl1.DataSource = stockList;
        }

        private void layoutControlGroup2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Refresh")
            {
                var stockList = stock.GetAllStockList().ToList();
                gridControl1.DataSource = null;
                gridControl1.DataSource = stockList;
            }
            else if(e.Button.Properties.Caption == "Export")
            {
                DialogResult pathSelected = SaveFileDialog.ShowDialog();
                if (pathSelected == DialogResult.OK)
                    FileControl.ExportGrid(gridView1, SaveFileDialog.FileName);
            }
            else if (e.Button.Properties.Caption == "Close")
            {
                this.Close();
            }
        }
    }
}