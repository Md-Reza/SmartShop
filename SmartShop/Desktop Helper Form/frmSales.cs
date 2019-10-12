using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using DevExpress.XtraEditors;
using SmartShop.Properties;

namespace SmartShop.Desktop_Helper_Form
{
    public partial class frmSales : DevExpress.XtraEditors.XtraForm
    {
        public frmSales()
        {
            InitializeComponent();
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            txtUserName.EditValue = Settings.Default.UserName;
            txtComputerName.EditValue = System.Net.Dns.GetHostName();
        }
    }
}