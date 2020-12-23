using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SmartShop.SmartReports
{
    public partial class rptProductBarcodePrint : DevExpress.XtraReports.UI.XtraReport
    {
        public rptProductBarcodePrint()
        {
            InitializeComponent();
            DataSource = SmartShopReports.GetAllProductBarcode();
        }

    }
}
