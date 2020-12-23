using DevExpress.XtraReports.UI;

namespace SmartShop.SmartReports
{
    public partial class rptPosRePrint : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPosRePrint()
        {
            InitializeComponent();     
        }

        private void rptPosRePrint_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
           this.DataSource = SmartShopReports.GetAllSalesParentPosInvoice(Parameters["PosInvoice"].Value.ToString());
            DetailReport.DataSource = SmartShopReports.GetAllSalesChildPosInvoice(Parameters["PosInvoice"].Value.ToString());
        }

        private void xrLabel14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // XRTableCell xrTableCell23 = (XRTableCell)FindControl("xrTableCell23", true);
            XRLabel xrLabel21 = (XRLabel)FindControl("xrLabel21", true);

          ((XRLabel)sender).Text = xrLabel21.Value.ToString();
        }

        private void xrLabel17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xrLabel16 = (XRLabel)FindControl("xrLabel16", true);

            ((XRLabel)sender).Text = xrLabel16.Value.ToString();
        }

        private void xrLabel18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xrLabel15 = (XRLabel)FindControl("xrLabel15", true);

            ((XRLabel)sender).Text = xrLabel15.Value.ToString();
        }
    }
}
